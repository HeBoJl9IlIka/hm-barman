using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] private Color _color;

    public Color Color => _color;

    protected void SetColor(Color color)
    {
        _color = color;
    }
}
