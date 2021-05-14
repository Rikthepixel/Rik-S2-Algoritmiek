using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAlgo.Business
{
    public static class QuickSort
    {
        public delegate bool CompareFunction<T>(T a, T b);
        private static List<T> Swap<T>(List<T> List, int IndexA, int IndexB)
        {
            var Temp = List[IndexA];
            List[IndexA] = List[IndexB];
            List[IndexB] = Temp;
            return List;
        }

        private static int Partition<T>(List<T> List, int StartIndex, int EndIndex, CompareFunction<T> compareFunction)
        {
            T Pivot = List[StartIndex];
            int SwapIndex = StartIndex;

            for (int i = StartIndex + 1; i < EndIndex; i++)
            {
                if (compareFunction(List[i], Pivot))
                {
                    SwapIndex++;
                    Swap<T>(List, i, SwapIndex);
                }
            }
            Swap<T>(List, StartIndex, SwapIndex);
            return SwapIndex;
        }

        public static List<T> Sort<T>(List<T> List, int Start, int End, CompareFunction<T> compareFunction)
        {
            if (Start < End)
            {
                int Pivot = Partition<T>(List, Start, End, compareFunction);
                Sort<T>(List, 0, Pivot, compareFunction);
                Sort<T>(List, Pivot + 1, End, compareFunction);

            }

            return List;
        }

        public static List<T> Sort<T>(List<T> List, CompareFunction<T> compareFunction)
        {
            return Sort<T>(List, 0, List.Count, compareFunction);
        }
    }
}
