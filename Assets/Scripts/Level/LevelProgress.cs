using UnityEngine;
using UnityEngine.Events;

public class LevelProgress : MonoBehaviour
{
    private const float FullProgress = 100f;

    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private PouringState _pouringState;
    [SerializeField] private SelectingToppingState _selectingToppingState;
    [SerializeField] private LaunchingCupState _launchingCupState;
    [SerializeField] private int _numberPoints;
    [SerializeField] private int _multiplier;

    private float _progress;

    public event UnityAction<float> Progressed;

    private void OnEnable()
    {
        _shakerLayers.Filling += OnFilled;
        _pouringState.Poured += OnPoured;
        _selectingToppingState.Selected += OnSelected;
        _launchingCupState.Launched += OnLaunched;
    }

    private void OnDisable()
    {
        _shakerLayers.Filling -= OnFilled;
        _pouringState.Poured -= OnPoured;
        _selectingToppingState.Selected -= OnSelected;
        _launchingCupState.Launched -= OnLaunched;
    }

    private void OnFilled(float level)
    {
        _progress = level * _multiplier;
        Progressed?.Invoke(_progress);
    }
    
    private void OnPoured()
    {
        _progress += _numberPoints;
        Progressed?.Invoke(_progress);
    }
    
    private void OnSelected()
    {
        _progress += _numberPoints;
        Progressed?.Invoke(_progress);
    }

    private void OnLaunched()
    {
        _progress = FullProgress;
        Progressed?.Invoke(_progress);
    }
}
