using UnityEngine;
using UnityEngine.InputSystem;

namespace Polygon
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private ControllerCollision collision;
        [SerializeField] private Rigidbody rig;
        private new Transform camera;

        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float jumpForce;

        [Space]
        [SerializeField] private float moveAcceleration = 10f;
        [SerializeField] private float lookAcceleration = 15f;
        [SerializeField] private float lermMultiplier = 7f;

        public float CurrentSpeed { get; private set; }
        public bool IsGround => collision.ContactCollision.Count > 0;
        private Vector2 moveVector;

        public void Init(Camera camera)
        {
            this.camera = camera.transform;
        }

        public bool IsRunning(Vector2 direction) 
        { 
            return Keyboard.current.leftShiftKey.isPressed && direction.x < 0.25f && direction.x > -0.25f && direction.y > 0.5f; 
        }

        public void Move(Vector2 direction)
        {
            moveVector.x = Mathf.Lerp(moveVector.x, direction.x, Time.deltaTime * lermMultiplier);
            moveVector.y = Mathf.Lerp(moveVector.y, direction.y, Time.deltaTime * lermMultiplier);

            CurrentSpeed = Mathf.Lerp(CurrentSpeed, IsRunning(direction) ? runSpeed : walkSpeed, Time.deltaTime * 3);
        }

        public void Jump()
        {
            if (IsGround) rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            Vector3 camForward = camera.forward;
            Vector3 camRight = camera.right;

            Vector2 camForwardNorm = new Vector2(camForward.x, camForward.z).normalized;
            Vector2 camRightNorm = new Vector2(camRight.x, camRight.z).normalized;

            Vector2 moveInput = new(moveVector.x, moveVector.y);
            Vector2 moveDir = (camForwardNorm * moveInput.y + camRightNorm * moveInput.x) * CurrentSpeed;
            
            rig.velocity = Vector3.Lerp(rig.velocity, new(moveDir.x, rig.velocity.y, moveDir.y), Time.fixedDeltaTime * moveAcceleration);
            
            if (camForward.sqrMagnitude > 0.001f)
            {
                float angleDelta = Mathf.DeltaAngle(rig.rotation.eulerAngles.y, Mathf.Atan2(camForwardNorm.x, camForwardNorm.y) * Mathf.Rad2Deg);
                float rotationStep = Mathf.Clamp(angleDelta * lookAcceleration * Time.fixedDeltaTime, -Mathf.Abs(angleDelta), Mathf.Abs(angleDelta));

                rig.angularVelocity = new(0f, rotationStep * Mathf.Deg2Rad / Time.fixedDeltaTime, 0f);
            }
        }
    }
}