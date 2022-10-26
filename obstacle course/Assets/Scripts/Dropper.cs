using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigid_body;
    [SerializeField]float ellapsed_time ;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        rigid_body = GetComponent<Rigidbody>();
        rigid_body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>ellapsed_time)
        {
            renderer.enabled = true;
            rigid_body.useGravity = true;
        }
    }
}
