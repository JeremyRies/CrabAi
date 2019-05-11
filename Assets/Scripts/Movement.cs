using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    
}

public class Movement : MonoBehaviour
{
    public float Speed;

    public float LeftConstraint;
    public float RightConstraint;
    void FixedUpdate()
    {
        float xInput = 0;
        var currentPosition = transform.position;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentPosition.x < RightConstraint)
            {
                xInput = 1f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentPosition.x > LeftConstraint)
            {
                xInput = -1f;
            }
        }
        

        currentPosition = currentPosition + new Vector3(xInput, 0, 0) * Time.fixedDeltaTime * Speed;
        transform.position = currentPosition;
    }
}