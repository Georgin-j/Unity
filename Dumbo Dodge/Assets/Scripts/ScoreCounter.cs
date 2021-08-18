using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    int score;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Hit")
        {
        score++;
        Debug.Log(score);
        }
    }
}
