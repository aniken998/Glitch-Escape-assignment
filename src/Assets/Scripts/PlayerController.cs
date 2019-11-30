using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    public float speed = 6.0f;
    public float gravity = 20.0f;

    public GameObject map1;
    public GameObject map2;

    private bool isMap1 = true;
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

    void OnControllerColliderHit(ControllerColliderHit other){
        Debug.Log("collide success");
        if (other.gameObject.CompareTag("MapButton"))
        {
            Debug.Log("collide success");
            if(isMap1) {
                map1.SetActive(false);
                map2.SetActive(true);
                isMap1 = false;
            }
            else {
                map1.SetActive(true);
                map2.SetActive(false);
                isMap1 = true;
            }
        }
    }
}
