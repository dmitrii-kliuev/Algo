using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class AvailableCapturesForRook
    {
        /*https://leetcode.com/problems/available-captures-for-rook/
         * On an 8 x 8 chessboard, there is one white rook.  There also may be empty squares, 
         * white bishops, and black pawns.  These are given as characters 'R', '.', 'B', and 'p' respectively. 
         * Uppercase characters represent white pieces, and lowercase characters represent black pieces.

        The rook moves as in the rules of Chess: it chooses one of four cardinal 
        directions (north, east, west, and south), then moves in that direction until 
        it chooses to stop, reaches the edge of the board, or captures an opposite colored 
        pawn by moving to the same square it occupies.  Also, rooks cannot move into the 
        same square as other friendly bishops.

        Return the number of pawns the rook can capture in one move.

        [".",".",".",".",".",".",".","."],
        [".",".",".","p",".",".",".","."],
        [".",".",".","R",".",".",".","p"],
        [".",".",".",".",".",".",".","."],
        [".",".",".",".",".",".",".","."],
        [".",".",".","p",".",".",".","."],
        [".",".",".",".",".",".",".","."],
        [".",".",".",".",".",".",".","."]
        3


        [".",".",".",".",".",".",".","."],
        [".","p","p","p","p","p",".","."],
        [".","p","p","B","p","p",".","."],
        [".","p","B","R","B","p",".","."],
        [".","p","p","B","p","p",".","."],
        [".","p","p","p","p","p",".","."],
        [".",".",".",".",".",".",".","."],
        [".",".",".",".",".",".",".","."]
        0


        [".",".",".",".",".",".",".","."],
        [".",".",".","p",".",".",".","."],
        [".",".",".","p",".",".",".","."],
        ["p","p",".","R",".","p","B","."],
        [".",".",".",".",".",".",".","."],
        [".",".",".","B",".",".",".","."],
        [".",".",".","p",".",".",".","."],
        [".",".",".",".",".",".",".","."]
        3

         */
        [Fact]
        public void Test()
        {

        }
    }
}
