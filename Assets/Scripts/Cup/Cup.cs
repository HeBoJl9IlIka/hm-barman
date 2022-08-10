using UnityEngine;
using UnityEngine.Events;

public class Cup : MonoBehaviour
{
    [SerializeField] private FormFactor _type;

    public FormFactor Type => _type;

    public event UnityAction Flying;

    public enum FormFactor
    {
        Wine,
        Cognac,
        Bear
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Table table))
        {
            Flying?.Invoke();
        }
    }
}
