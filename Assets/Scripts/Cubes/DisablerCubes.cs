using System.Collections;
using UnityEngine;

public class DisablerCubes : Disabler<CubesPool>
{
    [SerializeField] private SpawnerBombs _spawnerBombs;

    private void Start()
    {
        StartCoroutine(KeepTrackEndLifeCubes());
    }

    private IEnumerator KeepTrackEndLifeCubes()
    {
        float delay = 1;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, Radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out Cube cube))
                {
                    if (cube.IsLifeTimeCounted)
                    {
                        _spawnerBombs.CreateBomb(cube.transform, cube.transform.rotation);

                        ObjectsPool.ReturnObject(cube);
                    }
                }
            }

            yield return timeWait;
        }
    }
}
