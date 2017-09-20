using System;
using NUnit.Framework;
using SortingHomework;

namespace SearchingHomeworkTests
{
    [TestFixture]
    public class SearchingTests
    {
        [TestCase]
        public void LinearSearchShouldReturnFalseInSearchingInEmptyCollection()
        {
            int[] data = new int[] { };
            SortableCollection<int> sortable = new SortableCollection<int>(data);
            bool found = sortable.LinearSearch(4);
            Assert.IsFalse(found);
        }

        [TestCase]
        public void LinearSearchShouldReturnTrueIfFindsAnElement()
        {
            int[] data = new int[] { 3, 5, 2, -10, 9 };
            SortableCollection<int> sortable = new SortableCollection<int>(data);
            bool found = sortable.LinearSearch(2);
            Assert.IsTrue(found);
        }

        [TestCase]
        public void LinearSearchShouldReturnFalseIfElementDoesntExist()
        {
            int[] data = new int[] { 1, 2, 3 };
            SortableCollection<int> sortable = new SortableCollection<int>(data);
            bool found = sortable.LinearSearch(4);
            Assert.IsFalse(found);
        }

        [TestCase]
        public void BinarySearchShouldReturnFalseInSearchingInEmptyCollection()
        {
            int[] data = new int[] { };
            SortableCollection<int> sortable = new SortableCollection<int>(data);
            bool found = sortable.BinarySearch(4);
            Assert.IsFalse(found);
        }

        [TestCase]
        public void BinarySearchShouldReturnTrueIfElementExists()
        {
            int[] data = new int[] { 1, 2, 5, 100, 230 };
            var sortable = new SortableCollection<int>(data);

            bool found = sortable.BinarySearch(5);
            Assert.IsTrue(found);
        }

        [TestCase]
        public void BinarySearchShouldReturnFalseIfElementDoesntExists()
        {
            int[] data = new int[] { 1, 5, 10, 25, 100 };
            var sortable = new SortableCollection<int>(data);

            bool found = sortable.BinarySearch(19);
            Assert.IsFalse(found);
        }

        [TestCase]
        public void BinarySearchShouldReturnTrueIFElementExistsInCollectionWithSizeOne()
        {
            int[] data = new int[] { 5 };
            var sortable = new SortableCollection<int>(data);

            bool found = sortable.BinarySearch(5);
            Assert.IsTrue(found);
        }

    }
}
