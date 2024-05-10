using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private CubesPool _cubesPool;

    private float _quantityCubes = 25;

    private void Start()
    {
        for (int i = 0; i < _quantityCubes; i++)
        {
            _cubesPool.Initialize();
        }

        StartCoroutine(CreateCubes());
    }

    private IEnumerator CreateCubes()
    {
        float delay = 0.5f;
        int minRandomIndex = 0;
        int maxRandomIndex = _targetPoints.Count - 1;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            int randomValue = Random.Range(minRandomIndex, maxRandomIndex);

            _cubesPool.GetObject(_targetPoints[randomValue].transform.position, transform.rotation);

            yield return timeWait;
        }
    }
}
