using UnityEngine;

public class Disabler<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _objectsPool;
    [SerializeField] private float _radius = 100f;
    [SerializeField] private Color _colorGizmos = Color.red;

    protected T ObjectsPool => _objectsPool;
    protected float Radius => _radius;
    protected Color ColorGizmoz => _colorGizmos;

    private void OnDrawGizmos()
    {
        Gizmos.color = _colorGizmos;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
