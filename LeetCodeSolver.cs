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

        static void Main()
        {
           Console.WriteLine(LeetCodeSolver.IsIsomorphicString("add", "egg"));
        }
    }
}
