using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [Header("General Setup Settings")]
    [SerializeField] InputAction movement;
    [SerializeField] GameObject[] lasers;
    [Tooltip("Player position change speed")][SerializeField] float offset_tune;
    [SerializeField] float x_range;
    [SerializeField] float y_range = 5f;
    [Header("Rotation factors")]
    [SerializeField] float pos_pitch_factor = -2f;
    [SerializeField] float control_pitch_factor = -15f;
    [SerializeField] float pos_yaw_factor = -5f;
    [SerializeField] float control_raw_factor = -10f;
    [Header("Throw")]
    float horizontal_throw;
    float vertical_throw;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        movement.Enable();
        
    }
    private void OnDisable()
    {
        movement.Disable();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            LasersSetActive(true);
        }
        else
        {
            LasersSetActive(false);
        }
    }
    void LasersSetActive(bool activation)
    {
        foreach(GameObject laser in lasers)
        {
            var emission_module = laser.GetComponent<ParticleSystem>().emission;
            emission_module.enabled = activation;
        }
    }
    
    void ProcessRotation()
    {
        float pitch_due_to_position = transform.localPosition.y * pos_pitch_factor;
        float pitch_due_to_control = vertical_throw * control_pitch_factor;
        float pitch = pitch_due_to_position+pitch_due_to_control;
        float yaw = transform.localPosition.x*pos_yaw_factor;
        float raw = horizontal_throw * control_raw_factor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,raw);
    }
    void ProcessTranslation()
    {
        horizontal_throw = movement.ReadValue<Vector2>().x;
        vertical_throw = movement.ReadValue<Vector2>().y;
        float x_offset = horizontal_throw * Time.deltaTime * offset_tune;
        float y_offset = vertical_throw * Time.deltaTime * offset_tune;
        float new_x_pos = transform.localPosition.x + x_offset;
        float new_y_pos = transform.localPosition.y + y_offset;
        float clamped_x_pos = Mathf.Clamp(new_x_pos, -x_range, x_range);
        float clamped_y_pos = Mathf.Clamp(new_y_pos, -y_range, y_range);
        transform.localPosition = new Vector3(
            clamped_x_pos,
            clamped_y_pos,
            transform.localPosition.z);
    }
}
