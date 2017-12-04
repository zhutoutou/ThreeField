using System.Collections.Generic;
using System.Threading;

namespace ZIT.Collections
{
    /// <summary>
    /// This class is used to store items in a thread safe manner.
    /// It uses System.Collections.Generic.List.internally.
    /// </summary>
    /// <typeparam name="TV">item type</typeparam>
    public class ThreadSafeList<TV>
    {
        /// <summary>
        /// Gets/adds/replaces an item by index.
        /// </summary>
        /// <param name="index">index to get/set value</param>
        /// <returns>Item associated with this index</returns>
        public TV this[int index]
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                   return _list[index];
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }

            set
            {
                _lock.EnterWriteLock();
                try
                {
                    _list[index] = value;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Gets count of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _list.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Internal collection to store items.
        /// </summary>
        protected readonly IList<TV> _list;

        /// <summary>
        /// Used to synchronize access to _list.
        /// </summary>
        protected readonly ReaderWriterLockSlim _lock;

        /// <summary>
        /// Creates a new ThreadSafeList object.
        /// </summary>
        public ThreadSafeList()
        {
            _list = new List<TV>();
            _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        }

        /// <summary>
        /// Checks if collection contains spesified item.
        /// </summary>
        /// <param name="item">item to check</param>
        /// <returns>True; if collection contains given item</returns>
        public bool Contains(TV item)
        {
            _lock.EnterReadLock();
            try
            {
                return _list.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Removes an item from collection.
        /// </summary>
        /// <param name="item">item to remove</param>
        public bool Remove(TV item)
        {
            _lock.EnterWriteLock();
            try
            {
                if (!_list.Contains(item))
                {
                    return false;
                }

                _list.Remove(item);
                return true;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Removes all items from collection.
        /// </summary>
        public void ClearAll()
        {
            _lock.EnterWriteLock();
            try
            {
                _list.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Add(TV item)
        {
             _lock.EnterWriteLock();
            try
            {
                _list.Add(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}