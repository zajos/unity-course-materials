using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject death_vfx;
    [SerializeField] Transform vfx_parent;
    ScoreBoard score_board;
    [SerializeField]int score_per_hit=1;
    private void Start()
    {
        score_board = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        KillEnemy();
        Scorer();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(death_vfx, transform.position, Quaternion.identity);
        vfx.transform.parent = vfx_parent;
        Destroy(gameObject);
    }

    private void Scorer()
    {
        score_board.IncreaseScore(score_per_hit);
    }
}
