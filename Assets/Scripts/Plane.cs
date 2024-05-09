using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public event Action CubeCollised;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            CubeCollised?.Invoke();
        }
    }
}
