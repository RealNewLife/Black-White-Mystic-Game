using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove1 : MonoBehaviourPun
{
    bool activeESC= true;
    private PhotonView pv;
    //PlayerMove
    private Rigidbody rb;
    public float runSpeed ;
    public GameObject cam;
    public Animator animator;
    public LayerMask layerBox;
    public float jump;
    public float gravity;
    float horizontal = 0;

    
    //Draw
    public GameObject weapon;
    public Draw1 draw;
    //[SerializeField] Camera m_camera;
    //public GameObject brush;
    //public float posDraw;
    //LineRenderer currentLineRenderer;
    //Vector3 lastPos;

    //Arrow
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 2000f;

    void Start()
    {
        draw = GetComponent<Draw1>();
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
            Jump();
            Run();
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
            transform.position += new Vector3(horizontal * runSpeed * Time.fixedDeltaTime, 0, 0);
        }
            
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce,ForceMode.Impulse);
    }

   void Jump()
    {
        bool isGround = Physics.Raycast(transform.position, Vector3.down, 1f, layerBox);
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = Vector2.up * jump;


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
            transform.eulerAngles = new Vector3(0, 0, 0);
            cam.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            cam.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
}
