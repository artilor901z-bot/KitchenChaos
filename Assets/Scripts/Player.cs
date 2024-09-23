using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serializeField is used to make the variable visible in the inspector
    //in the same time, it is private
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;


    private bool isWalking;

    private void Update()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //if use =, the object will move to the position of the inputVector
        //if use +=, the object will move to the position of the inputVector + the current position

        Vector3 moveDir=new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed* Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        //transform.forward is the direction that the object is facing
        float rotateSpeed = 10f;    
        transform.forward =Vector3.Slerp(transform.forward, moveDir,Time.deltaTime*rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
