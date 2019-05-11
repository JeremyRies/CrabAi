using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] private CrabAgent _agent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall();
            _agent.Done();
        }
    }
}