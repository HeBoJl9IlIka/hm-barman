using UnityEngine;
using LiquidVolumeFX;

[RequireComponent(typeof(LiquidVolume))]
public class Cocktail : MonoBehaviour
{
    [SerializeField] private MixedState _mixedState;
    [SerializeField] private float _multiplier;


    private LiquidVolume _liquidVolume;

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    private void OnEnable()
    {
        _mixedState.Moving += OnMoving;
    }

    private void OnDisable()
    {
        _mixedState.Moving += OnMoving;
    }

    private void OnMoving()
    {
        _liquidVolume.alpha = _mixedState.MixingTime / _multiplier;
    }
}
