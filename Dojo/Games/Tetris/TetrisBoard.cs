using System.Text;
using System.Text.Json;

namespace Dojo.Games.Tetris;

/*-
 * #%L
 * Codenjoy - it's a dojo-like platform from developers to developers.
 * %%
 * Copyright (C) 2012 - 2022 Codenjoy
 * %%
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public
 * License along with this program.  If not, see
 * <http://www.gnu.org/licenses/gpl-3.0.html>.
 * #L%
 */

public class TetrisBoard : AbstractBoard<TetrisElement>
{
    private static Dictionary<char, TetrisElement> ElementsMap = new()
    {
        { 'I', TetrisElement.BLUE }, { 'J', TetrisElement.CYAN }, { 'L', TetrisElement.ORANGE },
        { 'O', TetrisElement.YELLOW }, { 'S', TetrisElement.GREEN }, { 'T', TetrisElement.PURPLE },
        { 'Z', TetrisElement.RED }
    };
    
    public TetrisBoard(string boardString) : base(boardString) { }
    
    public Point GetCurrentFigureBottomLeftPoint()
    {
        using var doc = JsonDocument.Parse(BoardString);
        var root = doc.RootElement;
        var currentFigurePoint = root.GetProperty("currentFigurePoint");
        var x = currentFigurePoint.GetProperty("x").GetInt32();
        var y = currentFigurePoint.GetProperty("y").GetInt32();
        return new Point(x, y);
    }

    public TetrisElement GetCurrentFigureType()
    {
        using var doc = JsonDocument.Parse(BoardString);
        var root = doc.RootElement;
        var currentFigureType = ParseTetrisElement(root.GetProperty("currentFigureType"));
        return currentFigureType;
    }

    public IReadOnlyList<TetrisElement> GetFutureFigureTypes()
    {
        using var doc = JsonDocument.Parse(BoardString);
        var root = doc.RootElement;
        var futureFigures = root.GetProperty("futureFigures")
            .EnumerateArray()
            .Select(ParseTetrisElement)
            .ToList();
        return futureFigures;
    }

    public GlassBoard GetGlass()
    {
        using var doc = JsonDocument.Parse(BoardString);
        var root = doc.RootElement;
        var layers = root.GetProperty("layers").EnumerateArray();
        var boardBuilder = new StringBuilder();
        foreach (var layer in layers)
        {
            boardBuilder.Append(layer.GetString());
        }

        var glassBoard = new GlassBoard(boardBuilder.ToString());
        return glassBoard;
    }

    private TetrisElement ParseTetrisElement(JsonElement jsonElement)
    {
        var figureType = char.Parse(jsonElement.ToString());
        return ElementsMap[figureType];
    }
}
