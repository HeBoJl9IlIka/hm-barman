using UnityEngine;

public class GettingTopping : MonoBehaviour
{
    [SerializeField] private Topping _topping;

    public Topping Topping => _topping;
}
