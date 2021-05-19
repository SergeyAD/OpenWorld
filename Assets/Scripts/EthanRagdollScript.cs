using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanRagdollScript : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Vector3 _impulse;

    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;

    private void Death()
    {
        _animator.enabled = false;
        SetState(false);
        _rigidbodies[0].AddForce(_impulse, ForceMode.Impulse);
    }



    private void Revive()
    {
        SetState(true);
        _animator.enabled = true;
    }

    private void SetState(bool isAlive)
    {
        foreach (var bodies in _rigidbodies)
        {
            bodies.isKinematic = isAlive;
        }

        foreach (var collader in _colliders)
        {
            collader.enabled = !isAlive;
        }
    }

    private void Awake()
    {
        _rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        _colliders = gameObject.GetComponentsInChildren<Collider>();

        Revive();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (_animator.enabled)
        {
            Death();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_animator.enabled)
        {
            Revive();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Revive();
        }




    }

}
