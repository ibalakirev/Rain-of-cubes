using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Renderer))]

public class Bomb : ObjectGame
{
    private Renderer _renderer;
    private Color _currentColor;
    private Color _defaultColor = Color.black;
    private Coroutine _coroutine;
    private float _minAlpha = 0f;
    private bool _isTransparencyReduced;
    private float _minSpeedTransparencyReduced = 0.01f;
    private float _maxSpeedTransparencyReduced = 0.03f;

    public bool IsTransparencyReduced => _isTransparencyReduced;

    private void OnEnable()
    {
        _isTransparencyReduced = false;

        _renderer = GetComponent<Renderer>();

        _renderer.material.color = _defaultColor;

        _currentColor = _renderer.material.color;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        StartCoroutine(ReduceAlphaColor(GetRandomLifeTime(_minSpeedTransparencyReduced, _maxSpeedTransparencyReduced)));
    }

    private IEnumerator ReduceAlphaColor(float speedTransparencyReduced)
    {
        float delay = 0.2f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while(_currentColor.a > _minAlpha)
        {
            _currentColor.a = Mathf.MoveTowards(_currentColor.a, _minAlpha, speedTransparencyReduced);

            _renderer.material.color = _currentColor;

            yield return timeWait;
        }

        _isTransparencyReduced = true;
    }
}
