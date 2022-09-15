using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class SleepingBehavior : MonoBehaviour
{
    public Material AwakeMaterial;
    public Material AsleepMaterial;

    public Rigidbody _rigidbody = null;
    private MeshRenderer _meshRenderer = null;

    private bool _wasAsleep = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        bool isAsleep = _rigidbody.IsSleeping();
        //If the rigidbody went tp sleep
        if (isAsleep && !_wasAsleep)
        {
            _wasAsleep = true;
            //Change material to asleep material
            if (AsleepMaterial != null)           
                _meshRenderer.material = AsleepMaterial;
            
        }
        //If the rigidbody woke up 
        else if (!isAsleep && _wasAsleep)
        {
            _wasAsleep = false;
            //Change the material to awake material
            if (AwakeMaterial != null)
                _meshRenderer.material = AwakeMaterial;
        }                   
    }
}
