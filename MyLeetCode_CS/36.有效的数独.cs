/*
 * @lc app=leetcode.cn id=36 lang=csharp
 *
 * [36] 有效的数独
 */

// @lc code=start
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        bool[,] row  = new bool[9,9];
        bool[,] col  = new bool[9,9];
        bool[,] block  = new bool[9,9];
        
        for(int i=0;i<9;i++)
        {
            for(int j=0;j<9;j++)
            {
                if (board[i][j]=='.') continue;

                int num = (int)(board[i][j]-'1');
                // check row conflict
                if (row[i,num]) return false;   //occupied
                else row[i,num] = true;         //occupy
                // check column conflict
                if (col[j,num]) return false;   //occupied
                else col[j,num] = true;         //occupy
                // check box conflict
                int idx = i/3 *3 + j/3;         // box index
                if (block[idx,num]) return false;  //occupied
                else block[idx,num] = true;        //occupy
            }
        }
        return true;
    }
}
// @lc code=end

