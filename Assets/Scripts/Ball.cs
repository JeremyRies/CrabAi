using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 OriginPosition;

    public Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = OriginPosition;
        Rigidbody2D.velocity = Vector3.zero;
    }
}
