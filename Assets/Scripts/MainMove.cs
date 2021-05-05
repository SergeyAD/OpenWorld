using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{
    public GameObject mainObject;
    public float speedWalk;
    public float speedRun;
    public float speedTurn;
    public Animator anim;
    
    public GameObject lightObject;


    public float StartAnimTime = 0.3f;
    public float StopAnimTime = 0.15f;
    public float allowPlayerRotation = 0.1f;

    private Vector3 _vector;
    private float _turn;
    private bool _lamp = false;
    public bool _isRun = false;

    private void Awake()
    {
        lightObject.SetActive(_lamp);
    }

    private void Update()
    {
        _vector.z = Input.GetAxis("Vertical");
        _turn = Input.GetAxis("Horizontal");
        float speed;
        // Движение игрока
        if (_isRun)
        {
            speed = speedRun;
        } else
        {
            speed = speedWalk;
        }

        var _move = _vector * speed * Time.deltaTime;
        var turn = _turn * speedTurn * Time.deltaTime;


        //mainObject.transform.Translate(_move);
        //mainObject.transform.Rotate(new Vector3(0, turn, 0));
        //Debug.LogWarning("speed = "+ _vector.z * speed + " turn = " + _turn);
        anim.SetFloat("Speed", _vector.z * speed);
        anim.SetFloat("Direction", _turn);

        //Включение / выключение фонарика

        if (Input.GetKeyDown(KeyCode.F))
        {
            _lamp = !_lamp;
            lightObject.SetActive(_lamp);
        }

        // Режим бега
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRun = false;
        }

    }

    private void FixedUpdate()
    {
 
    }

}
