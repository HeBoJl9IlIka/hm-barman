using UnityEngine;
using UnityEngine.Events;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private CheckCupChoiceState _checkCupChoiceState;
    [SerializeField] private CheckChoisToppingsState _checkChoisToppingsState;
    [SerializeField] private int _numberPoints;
    [SerializeField] private int _multiplier;

    private float _progress;

    public event UnityAction<float> Progressed;

    private void OnEnable()
    {
        _shakerLayers.Filled += OnFilled;
        _checkCupChoiceState.Completed += OnCompletedCupChoice;
        _checkChoisToppingsState.Completed += OnCompletedChoisToppings;
    }

    private void OnDisable()
    {
        _shakerLayers.Filled -= OnFilled;
        _checkCupChoiceState.Completed -= OnCompletedCupChoice;
        _checkChoisToppingsState.Completed -= OnCompletedChoisToppings;
    }

    private void OnFilled(float level)
    {
        _progress = level * _multiplier;
        Progressed?.Invoke(_progress);
    }
    
    private void OnCompletedCupChoice()
    {
        _progress += _numberPoints;
        Progressed?.Invoke(_progress);
    }
    
    private void OnCompletedChoisToppings()
    {
        _progress += _numberPoints;
        Progressed?.Invoke(_progress);
    }
}
