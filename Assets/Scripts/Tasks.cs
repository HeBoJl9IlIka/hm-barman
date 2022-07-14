using LiquidVolumeFX;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] private LiquidVolume.LiquidLayer[] _drinks;
    [SerializeField] private float _dispersion;
    [SerializeField] private Cup _cup;
    [SerializeField] private Topping _topping;

    public IReadOnlyList<LiquidVolume.LiquidLayer> Drinks => _drinks;
    public float Dispersion => _dispersion;
    public Cup Cup => _cup;
    public Topping Topping => _topping;
}
