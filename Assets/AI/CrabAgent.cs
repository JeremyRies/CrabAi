﻿using MLAgents;
using UnityEngine;

public class CrabAgent : Agent
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private Rigidbody2D _ball;

   private float _lastActionTime;
   
   public override void AgentReset()
   {
      _rigidbody.velocity = Vector2.zero;

      var x = Random.Range(-4, -2);
      var localPos = transform.localPosition;
      transform.localPosition = new Vector3(x, localPos.y, localPos.z);
   }

   public override void CollectObservations()
   {
      AddVectorObs(transform.localPosition);
      
      AddVectorObs(_ball.position);
      AddVectorObs(_ball.velocity);
   }

   public override void AgentAction(float[] vectorAction, string textAction)
   {
      transform.localPosition += new Vector3(vectorAction[0], 0, 0) * Time.deltaTime;

      var sinceLastAction = Time.time - _lastActionTime;
      _lastActionTime = Time.time;
      AddReward(sinceLastAction);
   }
}
