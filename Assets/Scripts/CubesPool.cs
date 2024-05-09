using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;

    private int _poolSize = 98;
    private List<Cube> _cubesPool;

    public void InitializePool()
    {
        _cubesPool = new List<Cube>();

        for (int i = 0; i < _poolSize; i++)
        {
            Cube newCube = Instantiate(_prefabCube);

            _cubesPool.Add(newCube);

            newCube.gameObject.SetActive(false);
        }
    }

    public Cube GetObjectToPool(Vector3 targetPosition, Quaternion rotation)
    {
        if( _cubesPool.Count == 0)
        {
            return null;
        }
        else
        {
            Cube cube = _cubesPool[_cubesPool.Count - 1];

            cube.gameObject.SetActive(true);

            cube.transform.position = targetPosition;
            cube.transform.rotation = rotation;

            _cubesPool.Remove(cube);

            return cube;
        }
    }

    public void ReturnObjectToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);

        _cubesPool.Add(cube);
    }
}
