using System.Collections;
using UnityEngine;

public class SpawnerBombs : Spawner<BombsPool>
{
    private void Start()
    {
        for (int i = 0; i < QuantityOjects; i++)
        {
            ObjectsPool.Initialize();
        }

        StartCoroutine(ObserveActivityBombs());
    }

    public void CreateBomb(Transform transform, Quaternion rotation)
    {
        ObjectsPool.GetObject(transform.position, rotation);

        ReportCreatedObject();
    }

    private IEnumerator ObserveActivityBombs()
    {
        float delay = 0.5f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            GetQuantityActiveObjects(ObjectsPool.GetQuantityActiveObjects());

            ReportActiveObject();

            yield return timeWait;
        }
    }
}
