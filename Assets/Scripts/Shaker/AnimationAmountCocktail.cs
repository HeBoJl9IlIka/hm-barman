using UnityEngine;
using LiquidVolumeFX;
using System.Collections;

[RequireComponent(typeof(LiquidVolume))]
public class AnimationAmountCocktail : MonoBehaviour
{
    private const float Delay = 0.5f;
    private const float LevelStep = 0.015f;

    private LiquidVolume _liquidVolume;

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    public void Play()
    {
        StartCoroutine(ReduceLevel());
    }

    private IEnumerator ReduceLevel()
    {
        yield return new WaitForSeconds(Delay);

        while (_liquidVolume.level > 0)
        {
            _liquidVolume.level -= LevelStep;

            yield return null;
        }
    }
}
