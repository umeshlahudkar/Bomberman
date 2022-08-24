using System.Collections.Generic;

namespace Bomberman.Global
{
    public class ObjectPool<T> : GenericSingleton<ObjectPool<T>> where T : class
    {
        private List<PoolItem> pooledItem = new List<PoolItem>();

        protected T GetItem()
        {
            if (pooledItem.Count > 0)
            {
                PoolItem item = pooledItem.Find(it => it.IsUsed == false);
                if (item != null)
                {
                    item.IsUsed = true;
                    return item.Item;
                }
            }
            return CreateNewItem();
        }

        private T CreateNewItem()
        {
            PoolItem newItem = new PoolItem();
            newItem.Item = CreateNew();
            newItem.IsUsed = true;
            pooledItem.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateNew()
        {
            return null;
        }

        public void ReturnToPool(T item)
        {
            PoolItem temp = pooledItem.Find(it => it.Item.Equals(item));
            if (temp != null)
            {
                temp.IsUsed = false;
            }
        }

        class PoolItem
        {
            public T Item;
            public bool IsUsed;
        }
    }
}
