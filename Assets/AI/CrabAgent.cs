using MLAgents;
using UnityEngine;

public class CrabAgent : Agent
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private Rigidbody2D _ball;

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
}
