using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private List<T> _pool = new List<T>();

    public void Initialize()
    {
        T newObject = Instantiate(_prefab);

        _pool.Add(newObject);

        newObject.gameObject.SetActive(false);
    }

    public T GetObject(Vector3 targetPosition, Quaternion rotation)
    {
        if (_pool.Count == 0)
        {
            return null;
        }
        else
        {
            T newObject = _pool[_pool.Count - 1];

            newObject.gameObject.SetActive(true);

            newObject.transform.position = targetPosition;
            newObject.transform.rotation = rotation;

            _pool.Remove(newObject);

            return newObject;
        }
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);

        _pool.Add(obj);
    }

    public int GetQuantityActiveObjects()
    {
        return _pool.Count;
    }
}
