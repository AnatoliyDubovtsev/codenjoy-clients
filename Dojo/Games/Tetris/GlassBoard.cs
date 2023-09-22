namespace Dojo.Games.Tetris;

public class GlassBoard : AbstractBoard<TetrisElement>
{
    private TetrisElement[] Elements() => Enum.GetValues<TetrisElement>();

    public bool IsFree(int x, int y) => IsAt(new Point(x, y), TetrisElement.NONE);

    public List<Point> GetFigures() => Get(Elements().Where(x => x != TetrisElement.NONE).ToArray());

    public List<Point> GetFreeSpace() => Get(TetrisElement.NONE);

    public GlassBoard(string boardString) : base(boardString) { }
}