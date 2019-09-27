using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton sg;
    public gun _gun;
    private void Awake()
    {
        sg = this;
    }
}
