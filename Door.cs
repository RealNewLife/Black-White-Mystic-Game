using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isPlayer,isBox;
    public Transform buttonCheack;
    public LayerMask whatIsPlayer,whatIsBox;
    public float checkRadius,speed,doorPositionY,doorMove;
    private void Start()
    {
        isPlayer = false;
        doorPositionY = transform.position.y;
    }
    void FixedUpdate()
    {
            isPlayer = Physics2D.OverlapCircle(buttonCheack.position, checkRadius, whatIsPlayer);
            isBox = Physics2D.OverlapCircle(buttonCheack.position, checkRadius, whatIsBox);
    }
    void Update()
    {
        if(isPlayer == true || isBox == true)
        {
            if (transform.position.y < doorPositionY + doorMove)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y>=doorPositionY) 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            }
        }
    }
}
