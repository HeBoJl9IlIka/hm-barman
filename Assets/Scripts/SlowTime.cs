using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private const float Slowdown = 0.5f;
    private const float NormalTime = 1f;

    [SerializeField] private Cup[] _cups;
    [SerializeField] private GiftOpeningState _giftOpeningState;

    private void OnEnable()
    {
        foreach (Cup cup in _cups)
        {
            cup.Flying += OnFlying;
        }

        _giftOpeningState.Showed += OnShowed;
    }

    private void OnDisable()
    {
        foreach (Cup cup in _cups)
        {
            cup.Flying -= OnFlying;
        }

        _giftOpeningState.Showed += OnShowed;
    }

    private void OnFlying()
    {
        Time.timeScale = Slowdown;
    }

    private void OnShowed()
    {
        Time.timeScale = NormalTime;
    }
}
