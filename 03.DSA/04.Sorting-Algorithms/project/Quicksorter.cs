namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, collection.Count / 2);
        }

        private void QuickSort(IList<T> collection, int pivotIndex)
        {
            if (pivotIndex == 0)
            {
                return;
            }
            
            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }
                if (collection[pivotIndex].CompareTo(collection[i]) > 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }
            

        }
    }
}
