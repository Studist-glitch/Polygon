using UnityEngine;

namespace Polygon
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Rigidbody rig;

        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float jumpForce;

        public float CurrentSpeed { get; private set; }

        public void Move(Vector2 direction)
        {
            
        }

        private void FixedUpdate()
        {
            //rig.velocity = ;
            //rig.angularVelocity= ;
        }
    }
}