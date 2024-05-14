using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner—ubes : Spawner<CubesPool>
{
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private SpawnerBombs _spawnerBombs;

    private void Start()
    {
        for (int i = 0; i < QuantityOjects; i++)
        {
            ObjectsPool.Initialize();
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

            if (ObjectsPool.GetObject(_targetPoints[randomValue].transform.position, transform.rotation))
            {
                ReportCreatedObject();
            }

            GetQuantityActiveObjects(ObjectsPool.GetQuantityActiveObjects());

            ReportActiveObject();

            yield return timeWait;
        }
    }
}
