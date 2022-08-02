using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GettingTopping))]
public class ButtonSelectingTopping : EventTrigger
{
    private GettingTopping _buttonSelectingTopping;

    public event UnityAction<Topping> Pressed;

    private void Start()
    {
        _buttonSelectingTopping = GetComponent<GettingTopping>();
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Pressed?.Invoke(_buttonSelectingTopping.Topping);
    }
}
