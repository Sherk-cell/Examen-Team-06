using System;
using Input.Script;
using Spawner;
using UnityEngine;

namespace Car
{
    public class CarPlayerScript : MonoBehaviour
    {

        [Header("Car Controller: ")] 
        [SerializeField] private float baseSpeed = 7.5f;
        [SerializeField] private float accelerateSpeed = 1f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private InputHandler handler;
        [SerializeField] private ConnectGenerator despawnAfterTime;
        private CharacterController _characterController;
        
        private bool _isGoingLeft;
        private bool _isGoingRight;
        private const float _rotSpeed = 10f;
        private float _currentRotationSpeed;

        // Start is called before the first frame update
        private void Start() => characterController = GetComponent<CharacterController>();

        private void Update()
        {
            // Player automatically goes forward
            var transform1 = transform;
            characterController.Move(-transform1.right * (moveSpeed * Time.deltaTime));

            // Move left or right while the corresponding button is held down
            if (isGoingLeft || handler.phoneInput == InputState.Left)
            {
                characterController.Move(-transform.forward * (moveSpeed * Time.deltaTime));
                RotateCar(-1);
            }
            else if (isGoingRight || handler.phoneInput == InputState.Right)
            {
                characterController.Move(transform.forward * (moveSpeed * Time.deltaTime));
                RotateCar(1);
            }
            if (handler.phoneInput == InputState.None)
            {
                RotateCar(0);
                if (moveSpeed < baseSpeed)
                    ReturnSpeed();
            }
            else if (handler.phoneInput == InputState.Both)
                Brake();

            if (moveSpeed <= 0f)
            {
                moveSpeed = 0;
            }
        }

        private void Brake()
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime * accelerateSpeed);

            if (moveSpeed < 0.01f)
                moveSpeed = 0;
        }

        private void ReturnSpeed()
        {
            moveSpeed = Mathf.Lerp(moveSpeed, baseSpeed, Time.deltaTime * accelerateSpeed);

            if (moveSpeed > baseSpeed - 0.1f)
                moveSpeed = baseSpeed;
        }
        
        private void RotateCar(int dir)
        {
            var targetAngle = dir > 0 ? 115f : dir < 0 ? 65f : 90f;
            var currentAngle = transform.localEulerAngles.y;
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, rotSpeed, Time.deltaTime);
            var newAngle = Mathf.LerpAngle(currentAngle, targetAngle, currentRotationSpeed * Time.deltaTime);

            // Apply the new rotation to the car
            transform.localEulerAngles = new Vector3(0, newAngle, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StreetTile"))
                despawnAfterTime.getChunks += 1;
        }

        public void LoseSpeed(float speedLoss)
        {
            moveSpeed -= speedLoss;
        }
    }
}