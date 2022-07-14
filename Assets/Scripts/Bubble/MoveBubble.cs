using UnityEngine;

public class MoveBubble : MonoBehaviour
{
    [SerializeField] private ContainerFillingState _containerFillingState;

    private void OnEnable()
    {
        _containerFillingState.Pouring += OnPouring;
    }

    private void OnDisable()
    {
        _containerFillingState.Pouring -= OnPouring;
    }

    private void OnPouring()
    {
        transform.position = new Vector3(transform.position.x, _containerFillingState.CurrentPositionDrink);
    }
}
