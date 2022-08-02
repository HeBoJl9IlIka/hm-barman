using LiquidVolumeFX;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LiquidVolume))]
public class AnimationAmountCocktailCup : MonoBehaviour
{
    private const float Delay = 0.5f;
    private const float LevelStep = 0.007f;

    private LiquidVolume _liquidVolume;

    public bool IsFull { get; private set; }

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    public void Play()
    {
        StartCoroutine(IncreaseLevel());
    }

    private IEnumerator IncreaseLevel()
    {
        yield return new WaitForSeconds(Delay);

        while (_liquidVolume.level < 1)
        {
            _liquidVolume.level += LevelStep;

            yield return null;
        }

        IsFull = true;
    }
}
