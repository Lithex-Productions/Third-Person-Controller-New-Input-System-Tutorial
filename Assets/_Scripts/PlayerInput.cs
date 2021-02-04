using UnityEngine;
using UnityEngine.InputSystem;

namespace LP.ThirdPersonControllerNewInputSystemTut
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputAction movement;
        [SerializeField] private InputAction turning;

        private CharacterController controller = null;

        public float speed = 7;
        public float turnSpeed = 100;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            movement.Enable();
            turning.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
            turning.Disable();
        }

        private void Update()
        {
            Walk();
            Turn();
        }

        private void Walk()
        {
            float x = movement.ReadValue<Vector2>().x;
            float z = movement.ReadValue<Vector2>().y;

            Vector3 direction = transform.right * x + transform.forward * z;

            controller.Move(direction * speed * Time.deltaTime);
        }

        private void Turn()
        {
            float y = turning.ReadValue<float>() * turnSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up * y);
        }
    }
}

