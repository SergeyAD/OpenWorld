using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{
    public GameObject mainObject;
    public float speedRun;
    public float speedTurn;

    private Vector3 _vector;
    private float _turn;

    private void Update()
    {
        _vector.z = Input.GetAxis("Vertical");
        _turn = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // Движение игрока

        var _move = _vector * speedRun * Time.deltaTime;
        var turn = _turn * speedTurn * Time.deltaTime;

        
        mainObject.transform.Translate(_move);
        mainObject.transform.Rotate(new Vector3(0, turn, 0));

    }

}
