using LiquidVolumeFX;
using System.Collections.Generic;
using UnityEngine;

public class CleanLayers : MonoBehaviour
{
    private List<LiquidVolume.LiquidLayer> _layers;

    public LiquidVolume.LiquidLayer[] Get(LiquidVolume.LiquidLayer[] layers)
    {
        _layers = new List<LiquidVolume.LiquidLayer>();

        for (int i = 0; i < layers.Length; i++)
        {
            if (layers[i].amount > 0)
            {
                _layers.Add(layers[i]);
            }
        }

        return _layers.ToArray();
    }
}
