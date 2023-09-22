using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Games.Tetris
{
    public class TetrisSolver : ISolver
    {
        public string Get(IBoard gameBoard)
        {
            var board = gameBoard as TetrisBoard;
            return "RIGHT";
        }
    }
}
