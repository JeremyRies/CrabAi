using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall();
        }

        var crabAgent = FindObjectOfType<CrabAgent>();
        if (crabAgent != null)
        {
            crabAgent.Done();
        }
    }
}