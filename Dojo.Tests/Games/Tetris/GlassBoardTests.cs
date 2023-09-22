using Dojo.Games.Tetris;
using NUnit.Framework;

namespace Dojo.Tests.Games.Tetris;

[TestFixture]
[Category("tetris")]
public class GlassBoardTests
{
    private GlassBoard _glassBoard;

    [SetUp]
    public void SetUp()
    {
        _glassBoard = new TetrisBoard(_json).GetGlass();
    }

    [Test]
    [TestCase(18, 18, false)]
    [TestCase(0, 0, true)]
    [TestCase(14, 18, false)]
    public void Test_IsFree(int x, int y, bool expected)
    {
        Assert.AreEqual(expected, _glassBoard.IsFree(x, y));
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
            "..I..............I",
            "..I......OO......I",
            "..IOO..SSOOZZ....I",
            "..IOO.SSIIIIZZ...I"
        ]
    }
    """;
}