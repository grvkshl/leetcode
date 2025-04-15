using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayString.Easy
{
    public class ReverseProblems
    {
        public void ReverseString(char[] s)
        {
            int first = 0;
            int last = s.Length - 1;

            while (first < last)
            {
                char temp = s[first];
                s[first] = s[last];
                s[last] = temp;
                first++;
                last--;
            }
        }
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s)) return String.Empty;

            string[] strArray = s.Trim().Split(' ');
            int first = 0;
            int last = strArray.Length - 1;

            while (first < last)
            {
                string temp = strArray[first];
                strArray[first] = strArray[last];
                strArray[last] = temp;
                first++;
                last--;
            }
            string resultString = String.Empty;

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != "")
                {
                    resultString += strArray[i];
                    if (i < strArray.Length - 1)
                    {
                        resultString += " ";
                    }
                }

            }

            return resultString;
        }
        public string ReverseWords_new(string s)
        {
            s = s.Trim();
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        /// <summary>
        /// Input: s = ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
        /// Output: ["b","l","u","e"," ","i","s"," ","s","k","y"," ","t","h","e"]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public void ReverseWords_2(char[] s)
        {            
            int index = 0;
            int last = s.Length - 1;

            while (index < last) {
                char temp = s[last];
                s[last] = s[index];
                s[index] = temp;
                index++;
                last--;
            }


            int startPointer = 0;
            int lastPointer = s.Length-1;

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] == ' ') || i == (s.Length -1))
                {
                    if (i < lastPointer) lastPointer = i - 1;

                    while (startPointer < lastPointer)
                    {
                        char temp = s[lastPointer];
                        s[lastPointer] = s[startPointer];
                        s[startPointer] = temp;
                        startPointer++;
                        lastPointer--;
                    }
                    
                    startPointer = i+1;
                    lastPointer = s.Length - 1;
                }
            }
            foreach (char item in s)
            {
                Console.WriteLine($"{item}");
            }            

        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> valuePair = new Dictionary<int, int>();

            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int firstNum = target - nums[i];

                if (valuePair.ContainsValue(firstNum))
                {
                    int index = valuePair.FirstOrDefault(x => x.Value == firstNum).Key;
                    return new int[] { index, i };
                }

                if (!valuePair.ContainsValue(nums[i]))
                {
                    valuePair.Add(i, nums[i]);
                }
            }

            return result;
        }
        public bool IsPalindrom(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;

            StringBuilder strBuilder = new StringBuilder();
            s = s.ToLower();
            foreach (Char item in s)
            {
                if (Char.IsLetterOrDigit(item))
                {
                    strBuilder.Append(item);
                }
            }

            int strLen = strBuilder.Length;

            for (int i = 0; i < strLen; i++)
            {
                char beginLetter = strBuilder[i];
                char endLetter = strBuilder[(strLen - 1) - i];
                if (beginLetter != endLetter)
                {
                    return false;
                }

                if (strLen % 2 == 0)
                {
                    if (i == ((strLen - 1) - i - 1)) return true;
                }
                else
                {
                    if (i == (strLen - 1) - i) return true;
                }
            }
            return true;
        }
        public bool IsPalindromNew(string s)
        {
            s = s.ToLower();
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }

                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }

            return true;
        }
        public int MyAtoi(string s)
        {
            s = s.TrimStart();
            string resultStrg = String.Empty;

            int index = 0;
            int isExit = 0;
            foreach (Char item in s)
            {
                switch (item)
                {
                    case '-':
                        if (index > 0)
                        {
                            if (resultStrg == String.Empty)
                            {
                                for (int i = 1; i <= index; i++)
                                {
                                    resultStrg += '0';
                                }
                            }
                            isExit = 1; break;
                        }
                        resultStrg += item;
                        index++;
                        break;
                    case '.':
                        resultStrg += item;
                        index++;
                        break;
                    case '+':
                        if (index > 0)
                        {
                            if (resultStrg == String.Empty)
                            {
                                for (int i = 1; i <= index; i++)
                                {
                                    resultStrg += '0';
                                }
                            }
                            isExit = 1; break;
                        }
                        resultStrg += item;
                        index++;
                        break;
                    default:
                        if (char.IsLetter(item))
                        {
                            if (index > 0)
                            {
                                if (resultStrg == String.Empty)
                                {
                                    for (int i = 1; i <= index; i++)
                                    {
                                        resultStrg += '0';
                                    }
                                }
                            }
                            isExit = 1; break;
                        }
                        if (char.IsDigit(item))
                        {
                            if (item == '0' && resultStrg == String.Empty)
                            {
                                index++;
                            }
                            else
                            {
                                resultStrg += item;
                                index++;
                            }
                        }
                        break;
                }

                if (isExit == 1) { break; };
            }

            if (resultStrg.Length > 0)
            {
                return Convert.ToInt32(resultStrg);
            }
            return 0;

        }
        public int MyAtoi1(string s)
        {
            s = s.TrimStart();
            if (string.IsNullOrEmpty(s)) return 0;

            int i = 0, sign = 1, result = 0;

            // Check for sign
            if (s[i] == '-' || s[i] == '+')
            {
                sign = (s[i] == '-') ? -1 : 1;
                i++;
            }

            // Convert digits to integer
            while (i < s.Length && char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';

                // Check for overflow
                if (result > (int.MaxValue - digit) / 10)
                {
                    return (sign == 1) ? int.MaxValue : int.MinValue;
                }

                result = result * 10 + digit;
                i++;
            }

            return result * sign;
        }
    }
}
