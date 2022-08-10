using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System.Collections;

[RequireComponent(typeof(Image))]
public class GiftProgress : MonoBehaviour
{
    private const float _targetFillAmount = 0.2f;
    private const float _fillAmountStep = 0.01f;
    private const float _duration = 1f;
    private const float _delayIncrease = 0.3f;
    private const float _stepDelay = 0.03f;

    [SerializeField] private Image _imageProgress;
    [SerializeField] private TMP_Text _percentProgress;

    private float _currentFillAmount;

    private void Start()
    {
        int normalizedValue = (int)(_currentFillAmount * 100);
        _percentProgress.text = normalizedValue.ToString() + "%";
    }

    private void OnEnable()
    {
        _imageProgress.DOFillAmount(_targetFillAmount, _duration).SetDelay(_delayIncrease);
        StartCoroutine(Increase());
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(_delayIncrease);

        while (_currentFillAmount < _targetFillAmount)
        {
            _currentFillAmount += _fillAmountStep;
            int normalizedValue = (int)(_currentFillAmount * 100);
            _percentProgress.text = normalizedValue.ToString() + "%";

            yield return new WaitForSeconds(_stepDelay);
        }
    }
}
