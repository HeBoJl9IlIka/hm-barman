using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Topping))]
public class SelectingTopping : MonoBehaviour
{
    [SerializeField] private ButtonSelectingTopping[] _buttonsSelectingTopping;

    private Topping _topping;

    public event UnityAction<Topping> Selected;

    private void Start()
    {
        _topping = GetComponent<Topping>();
    }

    private void OnEnable()
    {
        foreach (var button in _buttonsSelectingTopping)
        {
            button.Pressed += OnPressed;
        }
    }

    private void OnDisable()
    {

        foreach (var button in _buttonsSelectingTopping)
        {
            button.Pressed -= OnPressed;
        }
    }

    private void OnPressed(Topping topping)
    {
        if (_topping.Type == topping.Type)
        {
            Selected?.Invoke(_topping);
        }
    }
}
