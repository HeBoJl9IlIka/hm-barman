using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GettingCup))]
public class ButtonSelectingCup : EventTrigger
{
    private GettingCup _buttonSelectingCup;

    public event UnityAction<Cup> Pressed;

    private void Start()
    {
        _buttonSelectingCup = GetComponent<GettingCup>();
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Pressed?.Invoke(_buttonSelectingCup.Cup);
    }
}
