using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controllerPlayer2 : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;

    [SerializeField]
    private float speed = 0;

    float sx;
    Rigidbody2D rb;
    int jump;

    public GameObject skillPoint;

    public float checkRadius;
    public Transform groundCheck;
    public Transform wallCheck;
    public int wallRange;
    public LayerMask whatIsGround,jumpPad;
    private bool isGround,isjumpPad;
    public float jumpForce;
    private Vector2 inputVector = Vector2.zero;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sx = transform.localScale.x;
        jump = 2;
    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isjumpPad = Physics2D.OverlapCircle(groundCheck.position, checkRadius, jumpPad);
        rb.velocity = new Vector2(inputVector.x * speed, rb.velocity.y);
        if (inputVector.x > 0)
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        if (inputVector.x < 0)
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }

    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void OnDrawGizmosSelected()
    {
        if (wallCheck == null)
        {
            return;
        }
        Gizmos.DrawWireCube(wallCheck.position, new Vector2(0.1f, 0.5f));
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(0.5f, 0.1f));
    }
    public void SetInputVector(Vector2 direction)
    {
        inputVector.x = direction.x;
        inputVector.y = direction.y;
    }

    public void SetInputJump(bool jump1)
    {
        if (isGround == true)
        {
            jump = 1;
        }
        if (jump1 && jump > 0 && isjumpPad == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            jump--;
        }
        if (isjumpPad == true && jump1 == true)
        {
            jump = 1;
            rb.velocity = Vector2.up * (jumpForce *1.5f);
        }
    }

    public void SetSpeed(bool setSpeed)
    {
        if(setSpeed == true)
        {
            speed = 0;
            skillPoint.SetActive(true);
        }
        if (setSpeed == false)
        {
            speed = 5;
            skillPoint.SetActive(false);
        }
    }

}
