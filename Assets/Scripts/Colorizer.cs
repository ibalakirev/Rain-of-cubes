using UnityEngine;

public class Colorizer : MonoBehaviour
{
    public void PaintObject(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Random.ColorHSV();
    }
}

