using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : class
{
    class PooledObjectDetails<T>
    {
        public T objectInPool;
        public bool isActive;
    }

    private List<PooledObjectDetails<T>> pooledObjectsList = new List<PooledObjectDetails<T>>();

    public virtual T GetObjectFromPool()
    {
        if(pooledObjectsList.Count > 0)
        {
            PooledObjectDetails<T> inactiveObject = pooledObjectsList.Find(objectInPool => !objectInPool.isActive);

            if(inactiveObject != null)
            {
                inactiveObject.isActive = true;
                return inactiveObject.objectInPool;
            }
        }

        return null;
    }

    public virtual void ReturnObjectInPool(T objectToAddInPool)
    {
        PooledObjectDetails<T> returnedObject = null;
            returnedObject = pooledObjectsList.Find(
                activeObjectInPool => activeObjectInPool.objectInPool.Equals(objectToAddInPool));

        if(returnedObject != null)
        {
            returnedObject.isActive = false;
        }
        else
        {
            returnedObject = new PooledObjectDetails<T>();
            returnedObject.objectInPool = objectToAddInPool;
            returnedObject.isActive = false;
            pooledObjectsList.Add(returnedObject);
        }
    }
}
