using UnityEngine;

public class GettingDrink : MonoBehaviour
{
    [SerializeField] private Drink _drink;

    public Drink Drink => _drink;
}
