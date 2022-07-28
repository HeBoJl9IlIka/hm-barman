using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class AnimatorBottle : MonoBehaviour
{
    [SerializeField] private float _delayPouring;
    [SerializeField] private float _delayStopped;

    [SerializeField] private UnityEvent _pouring;
    [SerializeField] private UnityEvent _stopped;

    public void PlayJetAnimation()
    {

    }

    public void StopJetAnimation()
    {

    }
}
