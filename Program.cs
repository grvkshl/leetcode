// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Leetcode.ArrayString.Easy;


Solution solution = new Solution();
solution.StartMethod();

public class Solution
{

    public void StartMethod()
    {
        char[] input = new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
        ReverseProblems rev = new ReverseProblems();
        rev.ReverseWords_2(input);
    }
   
}