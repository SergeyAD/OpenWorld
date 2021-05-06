using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float health;

    private void Start()
    {
        health = 100f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamagePoint>())
        {
            health -= other.GetComponent<DamagePoint>().damage;
            Camera.main.GetComponent<GUIview>().health = health;
        }
    }

}
