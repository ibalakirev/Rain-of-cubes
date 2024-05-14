using UnityEngine;

public class ObjectGame : MonoBehaviour
{
    protected float GetRandomLifeTime(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }
}
