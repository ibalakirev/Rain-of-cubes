using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Exploder))]

public class DisablerBombs : Disabler<BombsPool>
{
    private Exploder _exploder;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();

        StartCoroutine(KeepTrackEndLifeBombs());
    }

    private IEnumerator KeepTrackEndLifeBombs()
    {
        float delay = 1;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, Radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out Bomb bomb))
                {
                    if (bomb.IsTransparencyReduced)
                    {
                        _exploder.ExplodeAllObjectsRadius(bomb.transform);

                        ObjectsPool.ReturnObject(bomb);
                    }
                }
            }

            yield return timeWait;
        }
    }
}
