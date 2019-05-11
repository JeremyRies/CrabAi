using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 OriginPosition;

    public Rigidbody2D Rigidbody2D;

    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        var x = Random.Range(-2f, 2);
        transform.localPosition = new Vector3(x, OriginPosition.y, 0);
        Rigidbody2D.velocity = Vector3.zero;
    }
}
