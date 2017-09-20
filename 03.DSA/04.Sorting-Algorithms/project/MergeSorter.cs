namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count < 2)
            {
                return;
            }
            int n = collection.Count;
            int mid = collection.Count / 2;
            var left = new T[mid];
            var right = new T[n - mid];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = collection[i];
            }
            for (int i = mid; i < n; i++)
            {
                right[i - mid] = collection[i];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, collection);
        }

        private void Merge(T[] left, T[] right, IList<T> collection)
        {
            int nL = left.Length;
            int nR = right.Length;
            int leftIndex = 0;
            int rightIndex = 0;
            int i = 0;

            while (leftIndex < nL && rightIndex < nR)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    collection[i] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    collection[i] = right[rightIndex];
                    rightIndex++;
                }
                i++;
            }

            while (leftIndex < nL)
            {
                collection[i++] = left[leftIndex++];
            }

            while (rightIndex < nR)
            {
                collection[i++] = right[rightIndex++];
            }
        }
    }
}
