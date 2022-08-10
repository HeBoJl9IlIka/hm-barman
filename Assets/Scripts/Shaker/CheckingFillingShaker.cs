using LiquidVolumeFX;
using UnityEngine;
using UnityEngine.Events;

public class CheckingFillingShaker : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private CleanLayers _cleanLayers;
    [SerializeField] private Tasks _task;

    private LiquidVolume.LiquidLayer[] _layers;

    public event UnityAction Completed;

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPoured;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
    }

    private void OnPoured()
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
                        return;
                    }

                    if (_layers[i].amount < _task.Drinks[i].amount - _task.Dispersion)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            return;
        }

        Completed?.Invoke();
    }
}
