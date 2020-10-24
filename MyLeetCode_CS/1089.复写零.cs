/*
 * @lc app=leetcode.cn id=1089 lang=csharp
 *
 * [1089] 复写零
 */

// @lc code=start
public class Solution {
    public void DuplicateZeros(int[] arr) {

        // // Solution#1 - use Queue
        // Queue<int> queue = new Queue<int>();
        // foreach (int num in arr)
        //     queue.Enqueue(num);

        // for (int i=0;i<arr.Length;i++)
        // {
        //     int num = queue.Dequeue();
        //     arr[i] = num;
        //     if (num == 0 && i< arr.Length)
        //         arr[++i] = num;
        // }

        // // Solution#2v1 - O(n), O(1)
        // int l = arr.Length;
        // int i=0,j=0;    // index
        
        // while (j<l)
        // {
        //     if (arr[i++]==0) j+=2;
        //     else j++;
        // }
        // bool singleZero = j>l;
        // // Console.WriteLine("i={0}, j={1}, singleZero={2}", i,j, singleZero);

        // for (j=l-1;j>=0;j--)
        // {
        //     int tmp = arr[--i];

        //     if (tmp == 0)
        //     {
        //         if (!singleZero) arr[j--] = tmp;
        //         else singleZero = false;
        //     }
        //     arr[j] = tmp;
        //     // Console.WriteLine("i={0}, j={1}, singleZero={2}", i,j, singleZero);
        // }



        // // Solution#2v2 - O(n), O(1)
        // int l = arr.Length;
        // int i=0,j=0;    // index
        
        // while (j<l)
        // {
        //     if (arr[i++]==0) j+=2;
        //     else j++;
        // }
        // // Console.WriteLine("i={0}, j={1}", i,j);


        // if (j==l)
        // {
        //     j = l-1;
        // }
        // else
        // {
        //     // the last zero is not repeated
        //     arr[l-1] = 0;
        //     j = l-2;
        //     i --;
        // }
        // // Console.WriteLine("i={0}, j={1}", i,j);

        // for (;j>=0;j--)
        // {
        //     if (arr[--i] == 0)
        //         arr[j--] = arr[i];  // repeat
        //     arr[j] = arr[i];
        // }


        // // Solution#2v3 - O(n), O(1)
        // int l = arr.Length;
        // int i=0,j=0;    // index
        
        // while (j<l)
        // {
        //     j++;    // regardless
        //     if (arr[i++]==0) 
        //     {
        //         if (j<l) j++;
        //         else
        //         {
        //             // the last zero is not repeated
        //             // fill the last cell
        //             arr[l-1] = 0;
        //             j--;
        //             i--;
        //             break;
        //         }
        //     }
        // }

        // for (j--;j>=0;j--)
        // {
        //     if (arr[--i] == 0)
        //         arr[j--] = arr[i];  // repeat
        //     arr[j] = arr[i];
        // }

        // Solution#2v4 - O(n), O(1)
        int l = arr.Length;
        int i=0,j=0;    // index
        
        for (j=0;j<l;j++)   // O(n)
        {
            if (arr[i++]==0) j++;
        }
        // Console.WriteLine("i={0}, j={1}", i,j);


        if (j>l)
        {
            // the last zero is not repeated
            // fill the last cell
            arr[l-1] = 0;
            j -= 2;
            i --;
        }
        // Console.WriteLine("i={0}, j={1}", i,j);

        for (j--;j>=0;j--)
        {
            if (arr[--i] == 0)
                arr[j--] = arr[i];  // repeat
            arr[j] = arr[i];
        }
    }
}
// @lc code=end

