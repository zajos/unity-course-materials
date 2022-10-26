using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float delay_time = 2f;
    [SerializeField]AudioClip crash_sfx;
    [SerializeField]AudioClip succes_sfx;
    AudioSource audio_source;
    bool is_transitioning = false;
    bool collision_disable = false;
    [SerializeField] ParticleSystem crash_particles;
    [SerializeField] ParticleSystem succes_particles;
    void Start()
    {
        audio_source = GetComponent<AudioSource>(); 
    }
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collision_disable = !collision_disable;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (is_transitioning || collision_disable)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                FinishSequence();
                break;
            default:
                CrashSequence();
                break;
        }      
    }
    void FinishSequence()
    {
        is_transitioning = true;
        audio_source.Stop();
        audio_source.PlayOneShot(succes_sfx);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay_time);
        succes_particles.Play();
    }
    void CrashSequence()
    {
        is_transitioning = true;
        audio_source.Stop();
        audio_source.PlayOneShot(crash_sfx);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay_time);
        crash_particles.Play();
    }
    void ReloadLevel()
    {
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index);
    }
    void LoadNextLevel()
    {
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;
        int next_scene_index = current_scene_index + 1;
        if (next_scene_index == SceneManager.sceneCountInBuildSettings)
        {
            next_scene_index = 0;
        }
        SceneManager.LoadScene(next_scene_index);
    }
}
