using LiquidVolumeFX;
using UnityEngine;
using UnityEngine.Events;

public class CheckingFillingState : State
{
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private CleanLayers _cleanLayers;
    [SerializeField] private Tasks _task;

    private LiquidVolume.LiquidLayer[] _layers;

    public bool IsReady { get; private set; }

    public event UnityAction Completed;

    private void OnEnable()
    {
        _layers = _cleanLayers.Get(_shakerLayers.Layers);

        if (_layers.Length == _task.Drinks.Count)
        {
            for (int i = 0; i < _task.Drinks.Count; i++)
            {
                if (_layers[i].color == _task.Drinks[i].color)
                {
                    if (_layers[i].amount > _task.Drinks[i].amount + _task.Dispersion)
                    {
                        IsReady = true;
                        return;
                    }

                    if (_layers[i].amount < _task.Drinks[i].amount - _task.Dispersion)
                    {
                        IsReady = true;
                        return;
                    }
                }
                else
                {
                    IsReady = true;
                    return;
                }
            }
        }
        else
        {
            IsReady = true;
            return;
        }

        Debug.Log("Completed");
        Completed?.Invoke();
        IsReady = true;
    }
}
