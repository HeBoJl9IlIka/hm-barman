using UnityEngine;

public class Topping : MonoBehaviour
{
    [SerializeField] private Form _type;

    public Form Type => _type;

    public enum Form
    {
        Watermelon,
        Berries,
        Lemon
    }
}
