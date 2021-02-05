using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove2 : MonoBehaviourPun
{
    //PlayerMove
    private PhotonView pv;
    private Rigidbody rb;
    public GameObject cam;
    public float runSpeed;
    public Animator animator;
    public LayerMask layerBox;
    public float jump;
    float speed, jump1;
    float horizontal = 0;


    //Draw
    //public Camera m_camera;
    //public GameObject brush;
    //public float posDraw;
    //LineRenderer currentLineRenderer;
    //Vector3 lastPos;

    //Arrow
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 2000f;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        if (!pv.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (photonView.IsMine == true)
        {
            Run();
            Jump();

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shoot();
            }

        }
    }
    void FixedUpdate()
    {
        if (photonView.IsMine == true)
        {
            transform.position -= new Vector3(horizontal * runSpeed * Time.fixedDeltaTime, 0, 0);
        }
    }

    //void Drawing()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        CreateBrush();
    //    }
    //    else if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        PointToMousePos();
    //    }
    //    else
    //    {
    //        currentLineRenderer = null;
    //    }
    //}

    //void CreateBrush()
    //{
    //    GameObject brushInstance = Instantiate(brush);
    //    currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

    //    //because you gotta have 2 points to start a line renderer, 
    //    Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
    //    mousePos.z = posDraw;
    //    currentLineRenderer.SetPosition(0, mousePos);
    //    currentLineRenderer.SetPosition(1, mousePos);

    //}

    //void AddAPoint(Vector3 pointPos)
    //{
    //    currentLineRenderer.positionCount++;
    //    int positionIndex = currentLineRenderer.positionCount - 1;
    //    pointPos.z = posDraw;
    //    currentLineRenderer.SetPosition(positionIndex, pointPos);
    //}

    //void PointToMousePos()
    //{
    //    Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
    //    if (lastPos != mousePos)
    //    {
    //        AddAPoint(mousePos);
    //        lastPos = mousePos;
    //    }
    //}

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

    void Jump()
    {
        bool isGround = Physics.Raycast(transform.position, Vector3.down, 1f, layerBox);
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rb.velocity = Vector2.up * jump;
            animator.SetBool("Jump", true);

        }
        if (isGround == false)
        {
            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }


        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rb.velocity = Vector2.up * jump;
            animator.SetBool("Jump", true);

        }
        if (isGround == false)
        {
            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    void Run()
    {
        horizontal = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            cam.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            cam.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}

