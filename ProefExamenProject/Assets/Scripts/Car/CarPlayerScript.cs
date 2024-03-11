using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

namespace Car
{
    public class CarPlayerScript : MonoBehaviour
    {

        [Header("Car Controller: ")] 
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private InputHandler handler;
        private CharacterController characterController;
        
        private bool isGoingLeft;
        private bool isGoingRight;
        private float rotSpeed = 10f;
        private float currentRotationSpeed = 0f;

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
                if (moveSpeed < 7.5f)
                    ReturnSpeed();
            }
            else if (handler.phoneInput == InputState.Both)
                Brake();
        }

        private void Brake()
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime * 2f);

            if (moveSpeed < 0.01f)
                moveSpeed = 0;
        }

        private void ReturnSpeed()
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 7.5f, Time.deltaTime * 2f);

            if (moveSpeed > 7.4f)
                moveSpeed = 7.5f;
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
    }
}
