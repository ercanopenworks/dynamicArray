using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dynamicArray
{
    class Program
    {
   

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {

            int N = n;
            int Q = queries.Count();
            int lastAnswer = 0;

            List<List<int>> sequences = new List<List<int>>();

            //ArrayList sequences = new ArrayList();

            for (int i = 0; i < n; i++)
            {
                sequences.Add(new List<int>());
            }

            List<int> output = new List<int>();


            for (int i = 0; i < Q; i++)
            {
                int q = queries[i][0];
                int x = queries[i][1];
                int y = queries[i][2];

                List<int> seq = sequences[(x ^ lastAnswer) % N];

                if (q == 1)
                {
                    seq.Add(y);
                }
                else if(q==2)
                {
                    lastAnswer = seq[y % seq.Count];
                    output.Add(lastAnswer);

                }
                //int seq = (x ^ lastAnswer) % N;

                //if (q == 1)
                //{
                //    List<int> tempList = new List<int>();
                //    tempList.Add(y);
                //    sequences[seq] = tempList;
                //}
                //if (q == 2)
                //{
                //    List<int> tempList = new List<int>();
                //    tempList = sequences[seq];

                //    lastAnswer = sequences[seq][y % tempList.Count];
                //    output.Add(lastAnswer);
                //}
            }
            return output;

        }

        static void Main(string[] args)
        {

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }


            List<int> result = dynamicArray(n, queries);

            Console.WriteLine(String.Join("\n", result));
        }
    }
}
