using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangingColor : MonoBehaviour
{
    PhotonView photonView;
    public Renderer myObject;
    public Material material1;
    public Material material2;
    public float cx=0;
    public float cy = 0;

    public void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet1")
        {
            photonView.RPC("SwitchColor0", RpcTarget.AllBuffered);
        }
        if (other.gameObject.tag == "bullet2")
        {

            photonView.RPC("SwitchColor1", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    void SwitchColor0()
    {
        transform.position = new Vector3(transform.position.x + cx, transform.position.y + cy, 0);
        myObject.sharedMaterial = material1;
    }
    [PunRPC]
    void SwitchColor1()
    {
        transform.position = new Vector3(transform.position.x - cx, transform.position.y - cy, -1);
        myObject.sharedMaterial = material2;
    }
}

