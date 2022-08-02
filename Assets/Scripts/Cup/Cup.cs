using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private FormFactor _type;

    public FormFactor Type => _type;

    public enum FormFactor
    {
        Wine,
        Cognac,
        Bear
    }
}
