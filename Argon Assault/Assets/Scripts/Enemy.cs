using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject death_vfx;
    [SerializeField] Transform vfx_parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(death_vfx, transform.position, Quaternion.identity);
        vfx.transform.parent = vfx_parent;
        Destroy(gameObject);
    }
}
