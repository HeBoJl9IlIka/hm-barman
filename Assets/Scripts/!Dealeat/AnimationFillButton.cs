using UnityEngine;
using DG.Tweening;

public class AnimationFillButton : MonoBehaviour
{
    [SerializeField] private RectTransform _targetPosition;
    [SerializeField] private RectTransform _defaultPosition;
    [SerializeField] private float _duration;

    public void Play()
    {
        transform.DOMove(_targetPosition.position, _duration);
    }

    public void Return()
    {
        transform.DOMove(_defaultPosition.position, _duration);
    }
}
