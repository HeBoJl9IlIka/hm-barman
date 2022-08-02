using UnityEngine;
using UnityEngine.Events;

public class SelectingCupState : State
{
    [SerializeField] ButtonSelectingCup[] _buttonsSelectingCup;

    public Cup Cup { get; private set; }
    public bool IsReady { get; private set; }

    public event UnityAction Selected;

    private void Start() { }

    private void OnEnable()
    {
        foreach (var button in _buttonsSelectingCup)
        {
            button.Pressed += OnPressed;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttonsSelectingCup)
        {
            button.Pressed += OnPressed;
        }
    }

    private void OnPressed(Cup cup)
    {
        Cup = cup;
        Selected?.Invoke();
        IsReady = true;
    }
}
