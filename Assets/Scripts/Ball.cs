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
        var x = Random.Range(-4, -2);
        transform.position = new Vector3(x, OriginPosition.y, 0);
        Rigidbody2D.velocity = Vector3.zero;
    }
}
