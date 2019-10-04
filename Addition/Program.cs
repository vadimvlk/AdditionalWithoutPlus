using System;
using System.Collections.Generic;


namespace Addition
{
    class Program
    {
        /// <summary>
        /// Additional without +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Sum a + b</returns>
        public static int AdditionBit(int a, int b)
        {
            if (b == 0) return a;
            int sum = a ^ b;
            int carry = (a & b) << 1;
            return AdditionBit(sum, carry);
        }
        /// <summary>
        /// Multiply without *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a*b</returns>
        public static int MultiplyBit(int a, int b)
        {
            int temp = 0;
            int result = 0;
            for (int i = 0; i < b-1; i++)
            {
                temp = i == 0 ? a : result;
                result = AdditionBit(a, temp);
            }
            return result;
        }
        /// <summary>
        /// Subtraction without -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Sum a - b</returns>
        public static int SubtractionBit(int a, int b)
        {
            int negative = ~b;
            negative = AdditionBit(negative, 1);
            return AdditionBit(a, negative);
        }

        /// <summary>
        /// Division without /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> a/b </returns>
        public static int DivisionBit(int a, int b)
        {
            int count = 0;
            int temp = 0;
            int result = 0;
            for (int i = 0; i < b; i++)
            {
                temp = i == 0 ? a : result;
                result = SubtractionBit(temp, b);
                count++;
                if (result <= 0) return count; 
            }
            return result;
        }

        /// <summary>
        /// Get Binary Number
        /// </summary>
        /// <param name="x"></param>
        /// <returns>bin format</returns>
        public static ICollection<int> GetBinaryNumber(int x)
        {
            int binary = 0;
            List<int> binarlist = new List<int>();
            do
            {                
                binary = x % 2;
                int temp = x / 2;
                binarlist.Add(binary);
                x = temp;
            } while (x>=1);

            return binarlist;
        }
        /// <summary>
        /// Replace var without temp
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Swap(ref int x, ref int y)
        {

            x = x ^ y;
            y = x ^ y;
            x = x ^ y;

            //shor

            //y ^= (x ^= y);          
            //x ^= y;

        }

        static void Main(string[] args)
        {
            int x = 7;
            int y = 5;
            Swap(ref x, ref y);
            Console.WriteLine($"x ={x},y={y} ");

            foreach (var item in GetBinaryNumber(155))
            {
                Console.Write(item);
            }
            Console.WriteLine();
           
            Console.WriteLine(DivisionBit(6,4));
            Console.WriteLine(AdditionBit(15,10)); 

            Console.WriteLine(MultiplyBit(12,12));
            Console.WriteLine(SubtractionBit(55,15));
            

            Console.ReadLine();

        }
    }
}
