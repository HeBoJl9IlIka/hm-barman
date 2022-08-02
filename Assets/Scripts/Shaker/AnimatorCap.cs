using UnityEngine;
using UnityEngine.Events;

public class AnimatorCap : MonoBehaviour
{
    [SerializeField] private ShakerClosingState _shakerClosingState;
    [SerializeField] private AnimationCapMovement _capMovement;

    private bool _isClosing;

    public event UnityAction Closed;

    private void Update()
    {
        if (_isClosing == false)
            return;

        if (_capMovement.IsClosed)
        {
            Closed?.Invoke();
            _isClosing = false;
        }
    }

    private void OnEnable()
    {
        _shakerClosingState.Closing += OnClosing;
    }

    private void OnDisable()
    {
        _shakerClosingState.Closing -= OnClosing;
    }

    private void OnClosing()
    {
        _capMovement.Play();
        _isClosing = true;
    }
}
