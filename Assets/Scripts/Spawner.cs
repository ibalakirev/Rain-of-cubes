using System;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _objectsPool;
    [SerializeField] private int _quantityOjects;

    private int _quantityObjectsCreated;
    private int _quantityObjectsActive;

    public event Action ObjectCreated;
    public event Action ActiveObjectsCounted;

    public int QuantityObjectsCreated => _quantityObjectsCreated;
    public int QuantityObjectsActive => _quantityObjectsActive;
    protected T ObjectsPool => _objectsPool;
    protected int QuantityOjects => _quantityOjects;

    protected void ReportCreatedObject()
    {
        _quantityObjectsCreated++;

        ObjectCreated?.Invoke();
    }

    protected void ReportActiveObject()
    {
        ActiveObjectsCounted?.Invoke();
    }

    protected int GetQuantityActiveObjects(int quantity)
    {
        return _quantityObjectsActive = _quantityOjects - quantity;
    }
}
