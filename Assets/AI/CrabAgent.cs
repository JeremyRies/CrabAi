using MLAgents;
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
      transform.position = new Vector3(x, transform.position.y, transform.position.z);
   }

   public override void CollectObservations()
   {
      AddVectorObs(transform.position);
      
      AddVectorObs(_ball.position);
      AddVectorObs(_ball.velocity);
   }

   public override void AgentAction(float[] vectorAction, string textAction)
   {
      transform.position += new Vector3(vectorAction[0], 0, 0);

      var sinceLastAction = Time.time - _lastActionTime;
      _lastActionTime = Time.time;
      AddReward(sinceLastAction);
   }
}
