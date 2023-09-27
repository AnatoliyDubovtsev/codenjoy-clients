using Dojo.Games.Tetris;
using NUnit.Framework;

namespace Dojo.Tests.Games.Tetris;

[TestFixture]
[Category("tetris")]
public class TetrisBoardTests
{
    [Test]
    public void Test_GetCurrentFigurePoint()
    {
        var board = new TetrisBoard(_json);
        var expected = new Point(4, 9);
        Assert.AreEqual(expected, board.GetCurrentFigurePoint());
    }
    
    [Test]
    [TestCase(TetrisElement.BLUE, 'I')]
    [TestCase(TetrisElement.CYAN, 'J')]
    [TestCase(TetrisElement.ORANGE, 'L')]
    [TestCase(TetrisElement.YELLOW, 'O')]
    [TestCase(TetrisElement.GREEN, 'S')]
    [TestCase(TetrisElement.PURPLE, 'T')]
    [TestCase(TetrisElement.RED, 'Z')]
    public void Test_GetCurrentFigureType_YellowFigure(TetrisElement expected, char figureChar)
    {
        const int figureIndex = 72;
        var charArr = _json.ToCharArray();
        charArr[figureIndex] = figureChar;
        var updatedJson = new string(charArr);
        var board = new TetrisBoard(updatedJson);
        Assert.AreEqual(expected, board.GetCurrentFigureType());
    }
    
    [Test]
    public void Test_GetFutureFigureTypes_FourNextFigures()
    {
        var board = new TetrisBoard(_json);
        var futureFigures = board.GetFutureFigureTypes();
        Assert.AreEqual(TetrisElement.GREEN, futureFigures[0]);
        Assert.AreEqual(TetrisElement.RED, futureFigures[1]);
        Assert.AreEqual(TetrisElement.BLUE, futureFigures[2]);
        Assert.AreEqual(TetrisElement.YELLOW, futureFigures[3]);
    }
    
    [Test]
    public void Test_GetGlass()
    {
        var board = new TetrisBoard(_json);
        var glass = board.GetGlass();
        Assert.AreEqual(18, glass.Size);
        Assert.AreEqual(28, glass.GetFigures().Count);
        Assert.AreEqual(296, glass.GetFreeSpace().Count);
    }

    private readonly string _json = """
    {
        "currentFigurePoint": {"x":4, "y":9},
        "currentFigureType": "O",
        "futureFigures": ["S", "Z", "I", "O"],
        "layers": [
            "..................",
            "........OO........",
            "........OO........",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..................",
            "..I...............",
            "..I......OO.......",
            "..IOO..SSOOZZ.....",
            "..IOO.SSIIIIZZ...."
        ]
    }
    """;
}