using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float reload_delay = 1f;
    [SerializeField] GameObject explosion;
    void OnCollisionEnter(Collision collision)
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        gameObject.GetComponent<Controller>().enabled = false;
        Invoke("Restart", reload_delay);
        explosion.GetComponent<ParticleSystem>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;

    }

    void Restart()
    {
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index);
    }
}
