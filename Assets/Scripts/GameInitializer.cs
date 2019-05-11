using System.Collections;
using System.Collections.Generic;
using MLAgents;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _gameSetup;
    [SerializeField] private int _amount;
    [SerializeField] private Camera _camera;
    
    void Start()
    {
        for (int i = 0; i < _amount; i++)
        {
            for (int j = 0; j < _amount; j++)
            {
                Instantiate(_gameSetup, new Vector3(15 * i, 15 * j, 0), Quaternion.identity);
            }
        }

        var bla = _amount / 2f * 15 - 7.5f;
        _camera.transform.position = new Vector3(bla, bla, -8);
        _camera.orthographicSize = _amount * 7.5f;
    }
}
