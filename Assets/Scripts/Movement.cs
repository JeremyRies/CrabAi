using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    void FixedUpdate()
    {
        float xInput = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xInput = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xInput = -1f;
        }
        
        var currentPosition = transform.position;
        currentPosition = currentPosition + new Vector3(xInput, 0, 0) * Time.fixedDeltaTime * Speed;
        transform.position = currentPosition;
    }
}