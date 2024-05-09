using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Colorizer), typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private float _quantityCollisions;
    private bool _isLifeTimeCounted = false;
    private Coroutine _coroutine;
    private Colorizer _colorizer;
    private MeshRenderer _meshRenderer;

    public bool IsLifeTimeCounted => _isLifeTimeCounted;

    private void Start()
    {
        _colorizer = GetComponent<Colorizer>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
            _quantityCollisions++;

            Paint(_quantityCollisions);

            GetRandomLifeTime();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(CountLifeTime(GetRandomLifeTime()));
        }
    }

    public float GetRandomLifeTime()
    {
        float minValueLifeTime = 2;
        float maxValueLifeTime = 5;

        return Random.Range(minValueLifeTime, maxValueLifeTime);
    }

    private IEnumerator CountLifeTime(float lifeTime)
    {
        float dealy = 1f;

        WaitForSeconds timeWait = new WaitForSeconds(dealy);

        for (int i = 0; i < lifeTime; i++)
        {
            yield return timeWait;
        }

        _isLifeTimeCounted = true;
    }

    private void Paint(float quantityCollisions)
    {
        float minQuantityCollisions = 1;

        if (quantityCollisions == minQuantityCollisions)
        {
            _colorizer.PaintObject(_meshRenderer);
        }
    }
}
