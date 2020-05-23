using Xunit;

namespace Algo.Tests.leetcode
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
        public void Test0()
        {
            var board = new[]
            {
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','p','.','.','.','.'},
                    new[]{'.','.','.','R','.','.','.','p'},
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','p','.','.','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'}
                };


            var s = new Solution();
            var actual = s.NumRookCaptures(board);
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Test1()
        {
            var board = new[]
            {
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','p','p','p','p','p','.','.'},
                    new[]{'.','p','p','B','p','p','.','.'},
                    new[]{'.','p','B','R','B','p','.','.'},
                    new[]{'.','p','p','B','p','p','.','.'},
                    new[]{'.','p','p','p','p','p','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'}
                };


            var s = new Solution();
            var actual = s.NumRookCaptures(board);
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Test2()
        {
            var board = new[]
            {
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','p','.','.','.','.'},
                    new[]{'.','.','.','p','.','.','.','.'},
                    new[]{'p','p','.','R','.','p','B','.'},
                    new[]{'.','.','.','.','.','.','.','.'},
                    new[]{'.','.','.','B','.','.','.','.'},
                    new[]{'.','.','.','p','.','.','.','.'},
                    new[]{'.','.','.','.','.','.','.','.'}
                };


            var s = new Solution();
            var actual = s.NumRookCaptures(board);
            Assert.Equal(3, actual);
        }

        public class Solution
        {
            public int NumRookCaptures(char[][] board)
            {
                var res = 0;
                var rRow = 0;
                var rColumn = 0;

                var rIsFound = false;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i][j] == 'R')
                        {
                            rRow = i;
                            rColumn = j;
                            rIsFound = true;
                            break;
                        }
                    }

                    if (rIsFound) break;
                }

                // up
                for (int i = rRow - 1; i >= 0; i--)
                {
                    if (board[i][rColumn] == 'p')
                    {
                        res++;
                        break;
                    }

                    if (board[i][rColumn] == 'B')
                        break;
                }

                // down
                for (int i = rRow + 1; i < 8; i++)
                {
                    if (board[i][rColumn] == 'p')
                    { res++; break; }

                    if (board[i][rColumn] == 'B')
                        break;
                }

                // left
                for (int j = rColumn + 1; j >= 0; j--)
                {
                    if (board[rRow][j] == 'p')
                    { res++; break; }

                    if (board[rRow][j] == 'B')
                        break;
                }

                // right
                for (int j = rColumn - 1; j < 8; j++)
                {
                    if (board[rRow][j] == 'p')
                    { res++; break; }

                    if (board[rRow][j] == 'B')
                        break;
                }

                return res;
            }
        }
    }
}
