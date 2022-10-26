using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float move_speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    
    void MovePlayer()
    {
        float x_value = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        float z_value = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        transform.Translate(x_value, 0, z_value);
    }
}
