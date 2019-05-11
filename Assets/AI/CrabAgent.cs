using MLAgents;
using UnityEngine;

public class CrabAgent : Agent
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private Rigidbody2D _ball;

   private Vector3 _startPosition;
   private float _lastActionTime;

   private void Awake()
   {
      _startPosition = transform.localPosition;
   }

   public override void AgentReset()
   {
      _rigidbody.velocity = Vector2.zero;
      transform.localPosition = _startPosition;
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
      transform.localPosition = new Vector3(Mathf.Clamp(newX, _startPosition.x - 4, _startPosition.x + 4), transform.localPosition.y, 0);

      var sinceLastAction = Time.time - _lastActionTime;
      _lastActionTime = Time.time;
      AddReward(sinceLastAction);
   }
}
