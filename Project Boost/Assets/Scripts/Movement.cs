using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigid_body;
    AudioSource audio_source;
    
    [SerializeField]float thrust_level;
    [SerializeField]float rotation_speed;
    
    [SerializeField] AudioClip thrust_sfx;
    
    [SerializeField] ParticleSystem main_booster;
    [SerializeField] ParticleSystem right_booster;
    [SerializeField] ParticleSystem left_booster;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StopThrusting()
    {
        audio_source.Stop();
        main_booster.Stop();
    }

    void StartThrusting()
    {
        rigid_body.AddRelativeForce(Vector3.up * Time.deltaTime * thrust_level);
        if (!audio_source.isPlaying)
        {
            audio_source.PlayOneShot(thrust_sfx);
        }

        if (!main_booster.isPlaying)
        {
            main_booster.Play();
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        else
        {
            NoRotation();
        }
    }

    void NoRotation()
    {
        right_booster.Stop();
        left_booster.Stop();
    }

    void TurnRight()
    {
        ApplyRotation(-rotation_speed);
        if (!left_booster.isPlaying)
        {
            left_booster.Play();
        }
        right_booster.Stop();
    }

    void TurnLeft()
    {
        ApplyRotation(rotation_speed);
        if (!right_booster.isPlaying)
        {
            right_booster.Play();
        }
        left_booster.Stop();
    }

    void ApplyRotation(float rotate)
    {
        rigid_body.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotate);
        rigid_body.freezeRotation = false;
    }

}
