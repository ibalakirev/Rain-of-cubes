using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _forceExplosionSeparation = 100f;
    private float _radiusExplosionSeparation = 50f;

    public void ExplodeAllObjectsRadius(Transform transformObject)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transformObject.position, _radiusExplosionSeparation);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody != null)
            {
                Explode(rigidbody, _forceExplosionSeparation, transformObject, _radiusExplosionSeparation);
            }
        }
    }

    private void Explode(Rigidbody rigidbody, float force, Transform transformObject, float radius)
    {
        rigidbody.AddExplosionForce(force, transformObject.position, radius);
    }
}
