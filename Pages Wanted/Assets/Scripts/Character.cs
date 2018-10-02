using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public CharacterController _controller;
    public bool canMove = true;
    public float speed = 10;
    public bool isP1 = true;
    private Vector3 move;
    public Character teammate;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
        if (this.tag == "P1")
        {
            isP1 = true;
            canMove = true;
            teammate = GameObject.FindGameObjectWithTag("P2").GetComponent<Character>();
        }
        else if(this.tag == "P2")
        {
            isP1 = false;
            canMove = false;
            teammate = GameObject.FindGameObjectWithTag("P1").GetComponent<Character>();
        }


	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            if (isP1)
            {
                move = new Vector3(Input.GetAxis("P1Horizontal"), 0, Input.GetAxis("P1Vertical"));
            }
            else
            {
                move = new Vector3(Input.GetAxis("P2Horizontal"), 0, Input.GetAxis("P2Vertical"));
            }
            _controller.Move(move * Time.deltaTime * speed); //maybe for running and tiptoeing
        }

        if (isP1 && Input.GetKey(KeyCode.Alpha1))
        {
            canMove = false;
            teammate.canMove = true;
        }

        else if (!isP1 && Input.GetKey(KeyCode.Alpha2))
        {
            canMove = false;
            teammate.canMove = true;
        }
    }
}
