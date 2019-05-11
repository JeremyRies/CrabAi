using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] private CrabAgent _player;
    [SerializeField] private CrabAgent _opponent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall();
            _player.Done();
            _opponent.Done();
        }
    }
}