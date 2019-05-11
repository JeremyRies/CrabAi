using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private bool _isLeft;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall();
            
            if (_isLeft)
            {
                _scoreSystem.ScoreLeft();
            }
            else
            {
                _scoreSystem.ScoreRight();
            }
        }
    }
}