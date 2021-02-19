using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Button1 : MonoBehaviour
{
    //public bool x = false;
    //public Puzzle1 puzzle1;
    //private void Awake()
    //{
    //    puzzle1 = FindObjectOfType<Puzzle1>();
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "bullet1" || other.gameObject.tag == "bullet2")
    //    {
    //        x = true;
    //    }
    //}
    //public void SetX()
    //{
    //    x = puzzle1.x1;
    //}


    private PhotonView photonView;
    public bool x = false;
    public Puzzle1 puzzle1;
    private void Awake()
    {
        photonView = PhotonView.Get(this);
        puzzle1 = FindObjectOfType<Puzzle1>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet1" || other.gameObject.tag == "bullet2")
        {
            photonView.RPC("valueX1", RpcTarget.AllBuffered);
        }
    }

    public void SetX()
    {
        photonView.RPC("SetX1", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void valueX1()
    {
        x = true;
    }
    [PunRPC]
    void SetX1()
    {
        x = puzzle1.x1;
    }
}
