using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonballBehavior : MonoBehaviour
{
    public float Power = 10.0f;
    public float ExplosionForce = 10.0f;
    public float ExplosionRadius = 2.0f;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = false;
        //Fire forward
        _rigidbody.AddForce(transform.forward * Power, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Explode 
        _rigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
    }
}
