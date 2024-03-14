using UnityEngine;

public class InputHandler : MonoBehaviour
{
        
    [Header("Phone Input Settings: ")]
    public InputState phoneInput;
    private bool leftTouched;
    private bool rightTouched;

    private void Update()
    {
        switch (Input.touchCount)
        {
            case > 0:
                TouchHandler();
                break;
            case < 1:
                phoneInput = InputState.None;
                break;
        }
    }


    private void TouchHandler()
    {
        for (var i = 0; i < UnityEngine.Input.touchCount; i++)
        {
            var touch = UnityEngine.Input.touches[i];
            if (touch.position.x < Screen.width / 2)
            {
                phoneInput = InputState.Left;
                if (touch.phase == TouchPhase.Began)
                    leftTouched = true;
                if (touch.phase == TouchPhase.Ended)
                    leftTouched = false;

            }
            else
            {
                phoneInput = InputState.Right;
                if (touch.phase == TouchPhase.Began)
                    rightTouched = true;
                if (touch.phase == TouchPhase.Ended)
                    rightTouched = false;
            }
            if (leftTouched && rightTouched)
                    rightTouched = true;
                if (touch.phase == TouchPhase.Ended)
                    rightTouched = false;
            }
            if (leftTouched && rightTouched)
            {
                phoneInput = InputState.Both;
            }
        }
    }


    public enum InputState
    {
        None = 0,
        Left = 1,
        Right = 2,
        Both = 4
    }
