using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float angle_x;
    [SerializeField] float angle_y;
    [SerializeField] float angle_z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angle_x, angle_y, angle_z);  
    }
}
