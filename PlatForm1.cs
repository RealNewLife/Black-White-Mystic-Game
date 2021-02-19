using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlatForm1 : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform platForm1;
    public float speed;
    private bool x = false; 
    Vector3 nextPos;
    PhotonView photonView;

    void Awake()
    {
        photonView = PhotonView.Get(this);
    }
    private void Update()
    {
        if (x == true)
        {
            platForm1.transform.position = Vector3.MoveTowards(platForm1.transform.position, pos1.position, speed * Time.deltaTime);
        }
        else
        {
            platForm1.transform.position = Vector3.MoveTowards(platForm1.transform.position, pos2.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1"|| other.gameObject.tag == "Player2")
        {
            x = true;
            //photonView.RPC("ButtonOn1", RpcTarget.AllBuffered);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
            x = false;
            //photonView.RPC("ButtonOn2", RpcTarget.AllBuffered);

        
            
    }
    [PunRPC]
    void ButtonOn1()
    {
       //platForm1.transform.position = Vector3.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
    }
    [PunRPC]
    void ButtonOn2()
    {
       //platForm1.transform.position = Vector3.MoveTowards(transform.position,pos2.position, speed * Time.deltaTime);
    }
}
