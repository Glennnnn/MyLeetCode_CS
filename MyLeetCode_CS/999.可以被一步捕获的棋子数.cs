/*
 * @lc app=leetcode.cn id=999 lang=csharp
 *
 * [999] 可以被一步捕获的棋子数
 */

// @lc code=start
public class Solution {
    public int NumRookCaptures(char[][] board) {

        int ans = 0;
        int N = 8;
        for (int i=0;i<N;i++)
        {
            for (int j=0;j<N;j++)
            {
                if (board[i][j] == 'R')
                {
                    Console.WriteLine("Rook at [{0},{1}]", i, j);

                    for (int n=i-1;n>=0;n--)
                    {
                        if (Char.IsLower(board[n][j]))      // Black
                        {
                            Console.WriteLine("North: {0} at [{1},{2}]", board[n][j], n, j);
                            ans += 1;
                            break;
                        }
                        else if (Char.IsUpper(board[n][j])) // White
                        {
                            break;
                        }
                    }
                    for (int s=i+1;s<N;s++)
                    {
                        if (Char.IsLower(board[s][j]))      // Black
                        {
                            Console.WriteLine("South: {0} at [{1},{2}]", board[s][j], s, j);
                            ans += 1;
                            break;
                        }
                        else if (Char.IsUpper(board[s][j])) // White
                        {
                            break;
                        }
                    }
                    for (int w=j-1;w>=0;w--)
                    {
                        if (Char.IsLower(board[i][w]))      // Black
                        {
                            Console.WriteLine("West : {0} at [{1},{2}]", board[i][w], i, w);
                            ans += 1;
                            break;
                        }
                        else if (Char.IsUpper(board[i][w])) // White
                        {
                            break;
                        }
                    }
                    for (int e=j+1;e<N;e++)
                    {
                        if (Char.IsLower(board[i][e]))      // Black
                        {
                            Console.WriteLine("East : {0} at [{1},{2}]", board[i][e], i, e);
                            ans += 1;
                            break;
                        }
                        else if (Char.IsUpper(board[i][e])) // White
                        {
                            break;
                        }
                    }

                    break;
                }
            }
        }

        return ans;

    }
}
// @lc code=end

