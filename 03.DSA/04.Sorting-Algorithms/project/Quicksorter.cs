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
            // TODO: in-place implementation

        }
    }
}
