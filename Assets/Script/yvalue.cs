using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yvalue : MonoBehaviour {


    public float yValue;
    public static yvalue ins;

    private void Awake()
    {
        ins = this;
    }
}
