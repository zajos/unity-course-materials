using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public void IncreaseScore(int amount_to_increase)
    {
        score += amount_to_increase;
        Debug.Log("Score is now: " + score);
    }
}
