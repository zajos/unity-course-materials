using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 starting_position;
    [SerializeField]Vector3 movement_vector;
    [SerializeField][Range(0,1)] float movement_factor;
    [SerializeField] float period=2f;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
      
        float cycles = Time.time / period;
        const float TAU = Mathf.PI * 2;
        Vector3 offset = movement_vector * movement_factor;
        transform.position = starting_position + offset;
        float raw_sin_wave = Mathf.Sin(cycles * TAU);
        movement_factor = (raw_sin_wave + 1f) / 2f;
        
        
    }
}
