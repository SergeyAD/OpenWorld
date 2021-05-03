using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    [SerializeField] GameObject sun;
    [SerializeField] float sunSpeed;

    private float _degree;

    private void Awake()
    {
        //_degree = sun.transform.rotation.x;
    }

    private void FixedUpdate()
    {
        sun.transform.Rotate(new Vector3(sunSpeed,0,0));
        //if (sun.transform.rotation.x > 360)
        //{
        //    sun.transform.Rotate(new Vector3(0, 0, 0));
        //}

    }
}
