using UnityEngine;

public class Colorizer : MonoBehaviour
{
    public void PaintObject(MeshRenderer meshRenderer, Color color)
    {
        meshRenderer.material.color = color;
    }
}

