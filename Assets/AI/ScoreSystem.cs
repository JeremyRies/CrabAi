using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private CrabAgent _leftAgent;
    [SerializeField] private CrabAgent _rightAgent;

    private int _scoreLeft;
    private int _scoreRight;

    private void Start()
    {
        UpdateScore();
    }

    public void ScoreLeft()
    {
        _scoreLeft++;
        
        _leftAgent.ScorePoint();
        _rightAgent.LosePoint();
        
        UpdateScore();
    }
    public void ScoreRight()
    {
        _scoreRight++;
        
        _rightAgent.ScorePoint();
        _leftAgent.LosePoint();
        
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreText.text = $"{_scoreLeft}:{_scoreRight}";
    }
}