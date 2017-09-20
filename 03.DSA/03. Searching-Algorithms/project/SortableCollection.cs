namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T currItem in this.Items)
            {
                if (item.CompareTo(currItem) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            return BinarySearchRec(0, this.Items.Count, item);
        }

        private bool BinarySearchRec(int minIndex, int maxIndex, T target)
        {
            if (minIndex >= maxIndex)
            {
                return false;
            }

            int midIndex = (maxIndex + minIndex) / 2;
            if (target.CompareTo(items[midIndex]) == 0)
            {
                return true;
            }

            if (target.CompareTo(this.Items[midIndex]) > 0)
            {
                return BinarySearchRec(midIndex + 1, maxIndex, target);
            }
            else
            {
                return BinarySearchRec(0, midIndex - 1, target);
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = 0; i < this.Items.Count - 2; i++)
            {
                int j = rng.Next(i, this.Items.Count);

                // exhange a[i] and a[j]
                T temp = this.items[i];
                this.items[i] = this.items[j];
                this.items[j] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }

}