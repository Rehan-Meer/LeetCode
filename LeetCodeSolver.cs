using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class LeetCodeSolver
    {
        public static bool IsIsomorphicString(string source, string target)
        {
            var dict = new Dictionary<char, char>();
            for (int i = 0; i < source.Length; i++)
            {
                if (dict.ContainsKey(source[i]))
                {
                    dict.TryGetValue(source[i], out char val);
                    if (val != target[i])
                        return false;
                    else
                        continue;
                }

                if (dict.ContainsValue(target[i]))
                {
                    if (dict.FirstOrDefault(x => x.Value == source[i]).Key != target[i])
                        return false;
                    else
                        continue;
                }
                else
                    dict.Add(source[i], target[i]);
            }
            return true;
        }
        public static bool IsPalindromeNumber(int number)
        {
            if (number < 0)
                return false;

            else
            {
                var temp = number;
                int reversed = 0;
                while (temp > 0)
                {
                    reversed = reversed * 10 + (temp % 10);
                    temp /= 10;
                }
                return number == reversed;
            }
        }
        public static int Reverse(int num)
        {
            bool isNegative = num < 0;
            var temp = isNegative ? 0 - num : num;
            int reversed = 0;
            bool isOutOfRange = false;
            while (temp > 0)
            {
                if (reversed > 0 && int.MaxValue / reversed < 10 && (int.MaxValue % reversed) >= (temp % 10))
                {
                    isOutOfRange = true;
                    break;
                }
                reversed = reversed * 10 + (temp % 10);
                temp /= 10;
            }
            return isOutOfRange ? 0 : isNegative ? 0 - reversed : reversed;
        }
        public static int SearchInsert(int[] nums, int target)
        {
            var lengthOfArray = nums.Length;
            var midpoint = lengthOfArray % 2 == 0 ? lengthOfArray / 2 : (lengthOfArray / 2) + 1;
            var startingIndex = lengthOfArray == 1 || target <= nums[midpoint] ? 0 : midpoint;
            var lastIndex = startingIndex == 0 && lengthOfArray != 1 ? midpoint : lengthOfArray - 1;
            var resultantIndex = lengthOfArray == 1 ? target <= nums[0] ? 0 : lengthOfArray : 0;

            for (int i = startingIndex; i <= lastIndex; i++)
            {
                if (target <= nums[i])
                {
                    resultantIndex = i;
                    break;
                }

                if (resultantIndex == 0 && i < lastIndex && target > nums[i] && target < nums[i + 1])
                {
                    resultantIndex = i + 1;
                    break;
                }

                if (i == lastIndex && resultantIndex == 0) // nomatch
                    return lengthOfArray;
            }
            return resultantIndex;
        }
        public static int FindNonMinOrMax(int[] nums)
        {
            var finalArray = nums.Except(new int[] { nums.Min(), nums.Max() });

            if (finalArray.Any())
                return finalArray.FirstOrDefault();
            else
                return -1;
        }
        public static int ThirdMax(int[] nums)
        {
            if (nums.Distinct().Count() < 3)
                return nums.Max();
            else
                return nums.Distinct().OrderByDescending(val => val).ToArray()[2];
        }
        public static int MissingNumber(int[] nums)
        {
            int rangeSum = 0;
            var minimum = nums.Min();
            var length = nums.Length;
            for (int i = minimum; i <= length; i++)
            {
                rangeSum += i;
            }

            var actualSum = nums.Sum();
            return rangeSum - actualSum;
        }
        public static bool IsPalindrome(string s)
        {
            var originalString = s.ToLower().ToCharArray();
            var modifiedString = new string(originalString.Where(char.IsLetterOrDigit).ToArray());
            var reversedString = new string(modifiedString.Reverse().ToArray());

            return modifiedString == reversedString;
        }
        public static int[] TwoSum(int[] nums, int target)
        {

            int firstIndex = -1;
            var len = nums.Length;

            for (int i = 0; i < len; i++)
            {

                if (firstIndex == -1)
                    firstIndex = i;

                if (i == len - 1 && nums[i] + nums[firstIndex] != target)
                {
                    i = firstIndex;
                    firstIndex = -1;
                    continue;
                }

                if (i != firstIndex && nums[i] + nums[firstIndex] == target)
                    return new int[] { firstIndex, i };

            }
            return new int[] { };
        }


        static void Main()
        {
            Console.WriteLine(LeetCodeSolver.IsIsomorphicString("add", "egg"));
        }
    }
}
