using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Button3 : MonoBehaviour
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
    //    x = puzzle1.x3;
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
            photonView.RPC("valueX3", RpcTarget.AllBuffered);
        }
    }

    public void SetX()
    {
        photonView.RPC("SetX3", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void valueX3()
    {
        x = true;
    }
    [PunRPC]
    void SetX3()
    {
        x = puzzle1.x3;
    }
}
