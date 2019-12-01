using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    public float speed = 6.0f;
    public float gravity = 20.0f;

    public GameObject map1;
    public GameObject map2;
    private bool isMap1 = true;

    private Vector3 moveDirection;

    public float startTime = 10.0f;
    private float currentTime;

    public Text timer;
    public Text GameOver;

    private bool isEndGame = false;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        currentTime = startTime;
        timer.text = currentTime.ToString("F2");
        isEndGame = false;
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

        currentTime -= Time.deltaTime;
        timer.text = currentTime.ToString("F2");

        if(currentTime <= 0 && !isEndGame) {
            GameOver.gameObject.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();
            isEndGame = true;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit other){
        if (other.gameObject.CompareTag("MapButton"))
        {
            changeMap();
        }

        if(other.gameObject.CompareTag("win") && !isEndGame) {
            GameOver.text = "YOU WIN";
            GameOver.gameObject.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();
            isEndGame = true;
        }
    }

    void changeMap() {
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
