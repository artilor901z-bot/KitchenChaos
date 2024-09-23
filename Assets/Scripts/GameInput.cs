using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputAction playerInputAction;
    private void Awake()
    {
       playerInputAction=  new PlayerInputAction();
       playerInputAction.Player.Enable();
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