﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
 
namespace ForumSurfer.Collections
{
    public class SortableObservableCollection<T> : ObservableCollection<T>
    {
        public SortableObservableCollection() : base()
        {

        }

        public SortableObservableCollection(ICollection<T> c) : base(c)
        {

        }

        public void Sort<TKey>(Func<T, TKey> keySelector, System.ComponentModel.ListSortDirection direction)
        {
            switch (direction)
            {
                case System.ComponentModel.ListSortDirection.Ascending:
                    {
                        ApplySort(Items.OrderBy(keySelector));
                        break;
                    }
                case System.ComponentModel.ListSortDirection.Descending:
                    {
                        ApplySort(Items.OrderByDescending(keySelector));
                        break;
                    }
            }
        }

        public void Sort<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            ApplySort(Items.OrderBy(keySelector, comparer));
        }

        private void ApplySort(IEnumerable<T> sortedItems)
        {
            var sortedItemsList = sortedItems.ToList();

            foreach (var item in sortedItemsList)
            {
                Move(IndexOf(item), sortedItemsList.IndexOf(item));
            }
        }


    }

}