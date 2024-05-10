using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Colorizer), typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private float _quantityCollisions;
    private bool _isLifeTimeCounted;
    private Coroutine _coroutine;
    private Colorizer _colorizer;
    private MeshRenderer _meshRenderer;
    private Color _colorRandom;
    private Color _colorDefault;

    public bool IsLifeTimeCounted => _isLifeTimeCounted;

    private void OnEnable()
    {
        _quantityCollisions = 0;
        _isLifeTimeCounted = false;
        _colorRandom = Random.ColorHSV();
        _colorDefault = Color.green;

        _colorizer = GetComponent<Colorizer>();
        _meshRenderer = GetComponent<MeshRenderer>();

        PaintInDefaultColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
            IncreaseQuantityCollisions();

            PaintInRandomColor(_quantityCollisions);

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
        WaitForSeconds timeWait = new WaitForSeconds(lifeTime);

        yield return timeWait;

        _isLifeTimeCounted = true;
    }

    private void IncreaseQuantityCollisions()
    {
        _quantityCollisions++;
    }

    private void PaintInRandomColor(float quantityCollisions)
    {
        float minQuantityCollisions = 1;

        if (quantityCollisions == minQuantityCollisions)
        {
            _colorizer.PaintObject(_meshRenderer, _colorRandom);
        }
    }

    private void PaintInDefaultColor()
    {
        _colorizer.PaintObject(_meshRenderer, _colorDefault);
    }
}
