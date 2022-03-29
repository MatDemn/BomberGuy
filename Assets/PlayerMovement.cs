using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;

    public CharacterStats charStats;

    public Animator anim;

    public LayerMask solidObstacle;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        charStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
        solidObstacle = LayerMask.GetMask("SolidObstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if(charStats.canMove) {
            float xMove = 0;
            float zMove = 0;
            if(charStats.playerNumber == 1) {
                xMove = Input.GetAxis("P1_Horizontal");
                zMove = Input.GetAxis("P1_Vertical");
            }
            else {
                xMove = Input.GetAxis("P2_Horizontal");
                zMove = Input.GetAxis("P2_Vertical");
            }
            if(xMove > 0) {
                MovePlayer(Vector3.right);
                transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
            }
            else if(xMove < 0) {
                MovePlayer(Vector3.left);
                transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
            }
            else if(zMove > 0) {
                MovePlayer(Vector3.forward);
                transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
            }
            else if(zMove < 0) {
                MovePlayer(Vector3.back);
                transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
            }
            else
                anim.SetBool("isRunning", false);
        }
    }

    private void MovePlayer(Vector3 target)
    {
        //if(Physics.Raycast(transform.position, target, .57f, solidObstacle)) {
        //    anim.SetBool("isRunning", false);
        //    return;
        //}
            
        anim.SetBool("isRunning", true);
        cc.Move(target * Time.deltaTime * charStats.playerMoveSpeed);
        transform.LookAt(transform.position+target); 
        transform.Rotate(new Vector3(0,90,0), UnityEngine.Space.Self);
    }

    public void ChangeSpeed(int changeAmount) 
    {
        if(charStats.playerMoveSpeed + changeAmount < 1) return;
        charStats.playerMoveSpeed += changeAmount;
    }
}
