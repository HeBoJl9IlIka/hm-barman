using UnityEngine;

public class GettingCup : MonoBehaviour
{
    [SerializeField] private Cup _cup;

    public Cup Cup => _cup;
}
