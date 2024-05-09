using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerCubes : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;

    private List<Cube> _cubes;

    private void Start()
    {
        _cubes = new List<Cube>();

        StartCoroutine(KeepTrackEndLifeCubes());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            _cubes.Add(cube);
        }
    }

    private IEnumerator KeepTrackEndLifeCubes()
    {
        float delay = 1;
        float minValueCount = 0;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            if(_cubes.Count > minValueCount)
            {
                for (int i = 0; i < _cubes.Count; i++)
                {
                    if (_cubes[i].IsLifeTimeCounted)
                    {
                        _cubesPool.ReturnObjectToPool(_cubes[i]);

                        _cubes.Remove(_cubes[i]);
                    }
                }
            }

            yield return timeWait;
        }
    }
}
