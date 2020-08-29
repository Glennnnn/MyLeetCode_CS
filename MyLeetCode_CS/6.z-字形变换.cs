/*
 * @lc app=leetcode.cn id=6 lang=csharp
 *
 * [6] Z 字形变换
 */

// @lc code=start
public class Solution {
    public string Convert(string s, int numRows) {

        if (numRows==1) return s;

        string[] rows = new string[numRows];
        int idx = 0;
        bool down = true;
        for(int i=0;i<rows.Length;i++)
        {
            rows[i] = "";   //initialize
        }

        foreach (char c in s)
        {
            rows[idx] += c;
            if (down && idx==numRows-1) down = false;
            else if (!down && idx==0) down = true;
            if (down) idx++;
            else idx--;
        }

        string ans = "";
        for(int i=0;i<rows.Length;i++)
        {
            //Console.WriteLine(rows[i]);
            ans += rows[i];
        }
        return ans;
    }






        /*
        // solution1
        if (numRows==1) return s;

        int len = s.Length;
        char[,] matrix = new char[numRows, len];

        int row = 0, col = 0;
        int dir = 0;    // 0-down, 1-up

        for (int i=0;i<len;i++)
        {
            matrix[row, col] = s[i];

            if (dir==0)
            {
                if (row == numRows-1)
                {
                    dir = 1;
                    row--;
                    col++;
                }
                else
                {
                    row ++;
                }
            }
            else
            {
                if (row == 0)
                {
                    dir = 0;
                    row ++;
                }
                else
                {
                    row --;
                    col++;
                }
            }
        }

        //displayMatrix(matrix);

        string ans = "";
        for(int i=0;i<matrix.GetLength(0);i++)
        {
            for (int j=0;j<matrix.GetLength(1);j++)
            {
                if (matrix[i,j] != '\0')
                    ans += matrix[i,j];
            }
        }
        return ans;


    }

    private void displayMatrix(char[,] matrix)
    {
        string s = "";
        for(int i=0;i<matrix.GetLength(0);i++)
        {
            for (int j=0;j<matrix.GetLength(1);j++)
            {
                if (matrix[i,j] == '\0') 
                    s += "[_]";
                else 
                    s += "[" + matrix[i,j] + "]";
            }
            s += "\r";
        }
        Console.WriteLine(s);
    }
    */
}
// @lc code=end

