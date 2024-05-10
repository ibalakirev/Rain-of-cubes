using System.Collections;
using UnityEngine;

public class DisablerCubes : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;

    private Vector3 _size = new Vector3(100f, 1f, 100f);

    private void Start()
    {
        StartCoroutine(KeepTrackEndLifeCubes());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _size);
    }

    private IEnumerator KeepTrackEndLifeCubes()
    {
        float delay = 1;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            Collider[] overlappedColliders = Physics.OverlapBox(transform.position, _size, Quaternion.identity);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out Cube cube))
                {
                    if (cube.IsLifeTimeCounted)
                    {
                        _cubesPool.ReturnObject(cube);
                    }
                }
            }

            yield return timeWait;
        }
    }
}
