using System;
using System.Collections.Generic;

namespace Sibice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sibice
            // https://open.kattis.com/problems/sibice 

            var parameters = EnterLine();

            List<string> ansewers = new List<string>();
            int match;
            for (int i = 0; i < parameters[0]; i++)
            {
                match = EnterMatchLength();
                ansewers.Add(SibiceResult(match, parameters));
            }

            PrintList(ansewers);
        }

        private static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static int EnterMatchLength()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a <= 0 || a > 1000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterMatchLength();
            }
            return a;
        }

        private static string SibiceResult(int a, int[] nums)
        {
            if (a > 0 && a <= Hypotenuse(nums[1], nums[2]))
                return "DA";
            else return "NE";
        }
        private static double Hypotenuse(int a, int b)
        {
            return(double) Math.Sqrt((double) a * a + b * b);
        }

        private static int[] EnterLine()
        {
            int[] res = new int[3] { 0, 0, 0 };
            string[] strArr = new string[3] { " ", " ", " " };
            try
            {
                strArr = Console.ReadLine().Split(' ', 3);
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = int.Parse(strArr[i]);
                }
                if (Conditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterLine();
            }
            return res;
        }
        private static bool Conditions(int[] nums)
        {
            var a = nums[0];
            var b = nums[1];
            var c = nums[2];

            if (a >= 1 && a <= 50 && b >= 1 && b <= 100 && c >= 1 && c <= 100)
                return true;
            else return false;
        }
    }
}
