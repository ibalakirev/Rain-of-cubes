using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private CubesPool _cubesPool;

    private void Start()
    {
        _cubesPool.InitializePool();

        StartCoroutine(CreateCubes());
    }

    private IEnumerator CreateCubes()
    {
        float delay = 0.1f;
        int minRandomIndex = 0;
        int maxRandomIndex = _targetPoints.Count - 1;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            int randomValue = Random.Range(minRandomIndex, maxRandomIndex);

            _cubesPool.GetObjectToPool(_targetPoints[randomValue].transform.position, transform.rotation);

            yield return timeWait;
        }
    }
}
