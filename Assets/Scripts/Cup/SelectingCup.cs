using UnityEngine;
using UnityEngine.Events;

public class SelectingCup : MonoBehaviour
{
    [SerializeField] private ButtonSelectingCup[] _buttonsSelectingCup;

    private Cup _cup;

    public event UnityAction Selected;

    private void Start()
    {
        _cup = GetComponent<Cup>();
    }

    private void OnEnable()
    {
        foreach(var button in _buttonsSelectingCup)
        {
            button.Pressed += OnPressed;
        }
    }

    private void OnDisable()
    {

        foreach (var button in _buttonsSelectingCup)
        {
            button.Pressed -= OnPressed;
        }
    }

    private void OnPressed(Cup cup)
    {
        if(_cup.Type == cup.Type)
        {
            Selected?.Invoke();
        }
    }
}
