using UnityEngine;

namespace DefaultNamespace
{
    public class Side : MonoBehaviour
    {
        private bool _containsBall;
        public bool ContainsBall => _containsBall;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Ball>() != null)
                _containsBall = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Ball>() != null)
                _containsBall = false;
        }
    }
}