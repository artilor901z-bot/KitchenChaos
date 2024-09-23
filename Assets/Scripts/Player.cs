using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serializeField is used to make the variable visible in the inspector
    //in the same time, it is private
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        //GetKey() is used to check if a key is being held down
        //Getkey() is used to check if a key is presses 
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        //if use =, the object will move to the position of the inputVector
        //if use +=, the object will move to the position of the inputVector + the current position

        Vector3 moveDir=new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed* Time.deltaTime;

        //transform.forward is the direction that the object is facing
        transform.forward = moveDir;
    }

}
