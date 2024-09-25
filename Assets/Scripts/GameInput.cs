using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;

    private PlayerInputAction playerInputAction;
    private void Awake()
    {
       playerInputAction=  new PlayerInputAction();
       playerInputAction.Player.Enable();

       playerInputAction.Player.Interact.performed += Interact_performed;
       playerInputAction.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    //2:44:22
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);

        //if(OnInteractAction != null)
        //{
        //    OnInteractAction(this, EventArgs.Empty);
        //}
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        //GetKey() is used to check if a key is being held down
        //Getkey() is used to check if a key is presses 

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
// in coding, we should manage things separately, so that we can easily debug and test the code