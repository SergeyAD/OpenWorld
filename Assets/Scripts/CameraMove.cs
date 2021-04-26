using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameraPoint;
    public GameObject objectPoint;

    public float speed;


    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, cameraPoint.transform.position, speed * Time.deltaTime);
        transform.LookAt(objectPoint.transform);
    }


}
