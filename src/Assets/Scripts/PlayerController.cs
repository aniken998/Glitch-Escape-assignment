using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    public float speed = 6.0f;
    
    public float gravity = 20.0f;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
    }
}
