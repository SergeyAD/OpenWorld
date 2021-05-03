using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{
    public GameObject mainObject;
    public float speedRun;
    public float speedTurn;
    public Animator anim;
    public float Speed;
    public GameObject lightObject;


    public float StartAnimTime = 0.3f;
    public float StopAnimTime = 0.15f;
    public float allowPlayerRotation = 0.1f;

    private Vector3 _vector;
    private float _turn;
    private bool _lamp = false;

    private void Awake()
    {
        lightObject.SetActive(_lamp);
    }

    private void Update()
    {
        _vector.z = Input.GetAxis("Vertical");
        _turn = Input.GetAxis("Horizontal");

        // Движение игрока

        var _move = _vector * speedRun * Time.deltaTime;
        var turn = _turn * speedTurn * Time.deltaTime;


        mainObject.transform.Translate(_move);
        mainObject.transform.Rotate(new Vector3(0, turn, 0));

        Speed = new Vector2(_turn, _vector.z).sqrMagnitude;
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }

        //Включение / выключение фонарика

        if (Input.GetKeyDown(KeyCode.F))
        {
            _lamp = !_lamp;
            lightObject.SetActive(_lamp);
        }

    }

    private void FixedUpdate()
    {
 
    }

}
