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

      var localPos = transform.localPosition;
      transform.localPosition = new Vector3(0, localPos.y, localPos.z);
   }

   public override void CollectObservations()
   {
      AddVectorObs(transform.localPosition);
      
      AddVectorObs((Vector2) _ball.transform.localPosition);
      AddVectorObs(_ball.velocity);
   }

   public override void AgentAction(float[] vectorAction, string textAction)
   {
      var newX = transform.localPosition.x + vectorAction[0] * 20 * Time.deltaTime;
      transform.localPosition = new Vector3(Mathf.Clamp(newX, -4, 4), transform.localPosition.y, 0);

      var sinceLastAction = Time.time - _lastActionTime;
      _lastActionTime = Time.time;
      AddReward(sinceLastAction);
   }
}
