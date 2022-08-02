using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent (typeof(GettingDrink))]
public class ButtonPouring : EventTrigger
{
    private GettingDrink _buttonPouring;

    public UnityAction<Drink> Pressed; 
    public UnityAction Released;

    private void Start()
    {
        _buttonPouring = GetComponent<GettingDrink>();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Pressed?.Invoke(_buttonPouring.Drink);
    }

    public override void OnPointerUp(PointerEventData data)
    {
        Released?.Invoke();
    }
}
