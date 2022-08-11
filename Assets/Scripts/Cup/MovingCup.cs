using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingCup : MonoBehaviour
{
    [SerializeField] private GiftOpeningState _giftOpeningState;
    [SerializeField] private Vector3 _defaultPosition;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _giftOpeningState.Showed += OnShowed;
    }

    private void OnDisable()
    {
        _giftOpeningState.Showed += OnShowed;
    }

    private void OnShowed()
    {
        _rigidbody.isKinematic = true;
        gameObject.SetActive(false);
    }
}
