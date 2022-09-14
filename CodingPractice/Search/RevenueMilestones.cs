using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Search
{
    public class RevenueMilestones
    {
        public static void Test()
        {
            Console.WriteLine("############# TEST 1 ######################");
            int[] revenues_1 = { 100, 200, 300, 400, 500 };
            int[] milestones_1 = { 300, 800, 1000, 1400 };
            int[] expected_1 = {2, 4, 4, 5};
            int[] output_1 = getMilestoneDays(revenues_1, milestones_1);           

            Console.Write("Expected: ");
            foreach (int exp in expected_1)
                Console.Write(exp + " ");
            Console.WriteLine("");
            Console.Write(" Results: ");
            foreach (int output in output_1)
                Console.Write(output + " ");
            Console.WriteLine("");
            

            Console.WriteLine("############# TEST 2 ######################");
            int[] revenues_2 = { 700, 800, 600, 400, 600, 700 };
            int[] milestones_2 = { 3100, 2200, 800, 2100, 1000 };
            int[] expected_2 = {5, 4, 2, 3, 2};
            int[] output_2 = getMilestoneDays(revenues_2, milestones_2);

            Console.Write("Expected: ");
            foreach (int exp in expected_2)
                Console.Write(exp + " ");
            Console.WriteLine("");
            Console.Write(" Results: ");
            foreach (int output in output_2)
                Console.Write(output + " ");
            Console.WriteLine("");

            Console.Read();            
        }

        private static int[] getMilestoneDays(int[] revenues, int[] milestones)
        {
            for (int i = 1; i <= milestones.Length; i++)
                revenues[i] = revenues[i] + revenues[i - 1];

            int[] outputs = new int[milestones.Length];

            for (int j = 0; j < milestones.Length; j++)
            {
                int output = -1;
                int minIdx = 0;
                int maxIdx = revenues.Length - 1;
                int milestone = milestones[j];

                while (minIdx <= maxIdx)
                {
                    int midIdx = minIdx + (maxIdx - minIdx) / 2;

                    if (revenues[midIdx] == milestone)
                    {
                        output = midIdx + 1;
                        break;
                    }
                    else if (revenues[midIdx] < milestone)
                    {
                        minIdx = midIdx + 1;
                    }
                    else
                    {
                        output = midIdx + 1;
                        maxIdx = midIdx - 1;
                    }

                }

                outputs[j] = output;
            }

            return outputs;
        }
    }
}
