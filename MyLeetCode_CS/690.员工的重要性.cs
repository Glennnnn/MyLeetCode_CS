/*
 * @lc app=leetcode.cn id=690 lang=csharp
 *
 * [690] 员工的重要性
 */

// @lc code=start
/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {

    Dictionary<int, Employee> myDic = new Dictionary<int, Employee>();
    public int GetImportance(IList<Employee> employees, int id) {
        // convert to dictionary, so that access is O(1)
        // O(n), add all employees into dictionary
        foreach(Employee e in employees)
        {
            myDic.Add(e.id, e);
        }
        // O(n), each employee is accessed once at max
        return CalcImportance(id);
    }

    private int CalcImportance(int id)
    {
        Employee e = myDic[id]; // O(1)
        int ans = e.importance;
        foreach(int sub in e.subordinates)
        {
            ans += CalcImportance(sub);
        }
        return ans;
    }
}
// @lc code=end

