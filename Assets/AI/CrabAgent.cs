using DefaultNamespace;
using MLAgents;
using UnityEngine;

public class CrabAgent : Agent
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private Rigidbody2D _ball;

   [SerializeField] private Side _playerSide;
   [SerializeField] private Side _opponentSide;

   [SerializeField] private bool _isRightPlayer;

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
      AddVectorObs(InvertX(transform.localPosition));
      
      AddVectorObs(InvertX((Vector2) _ball.transform.localPosition));
      AddVectorObs(InvertX(_ball.velocity));
   }

   private float InvertX(float scalar)
   {
      return _isRightPlayer ? -scalar : scalar;
   }

   private Vector2 InvertX(Vector2 vector)
   {
      return new Vector2(_isRightPlayer ? -vector.x : vector.x, vector.y);
   }
   
   private Vector3 InvertX(Vector3 vector)
   {
      return InvertX((Vector2) vector);
   }

   public override void AgentAction(float[] vectorAction, string textAction)
   {
      var newX = transform.localPosition.x + InvertX(vectorAction[0]) * 20 * Time.deltaTime;
      transform.localPosition = new Vector3(Mathf.Clamp(newX, _startPosition.x - 4, _startPosition.x + 4), transform.localPosition.y, 0);

      var sinceLastAction = Time.time - _lastActionTime;
      _lastActionTime = Time.time;
      
      if (_playerSide.ContainsBall)
         AddReward(-sinceLastAction);
      if (_opponentSide.ContainsBall)
         AddReward(sinceLastAction);
   }
}
