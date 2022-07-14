using UnityEngine;
using DG.Tweening;

public class DOTSetting : MonoBehaviour
{
    private void Start()
    {
        DOTween.SetTweensCapacity(500, 200);
    }
}
