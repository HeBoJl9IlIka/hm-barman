using DG.Tweening;
using UnityEngine;

public class AnimationShakerMovement : MonoBehaviour
{
    private const float DurationShaker = 0.2f;

    [SerializeField] private Transform _targetPositionShaker;
    [SerializeField] private Transform _defaultPositionShaker;
    [SerializeField] private Vector3 _targetRotateShaker;
    [SerializeField] private Vector3 _defaultRotateShaker;

    public bool IsClosed => transform.position == _defaultPositionShaker.position;

    public void Play()
    {
        float delayRotation = 0.1f;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_targetPositionShaker.position, DurationShaker));
        sequence.Insert(0, transform.DORotate(_targetRotateShaker, DurationShaker));

        sequence.Append(transform.DOMove(_defaultPositionShaker.position, DurationShaker));
        sequence.Insert(delayRotation, transform.DORotate(_defaultRotateShaker, DurationShaker));
    }
}
