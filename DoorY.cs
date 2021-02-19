using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DoorY : MonoBehaviour
{
    PhotonView photonView;
    public Transform door;
    public float openDoorX = 0f;
    public float openDoorY = 0f;
    public float openDoorZ = 0f;
    private bool openFirst = true;
    
    private void Awake()
    {
        photonView = PhotonView.Get(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet1" && openFirst == true)
        {
            photonView.RPC("OpenDoor1", RpcTarget.AllBuffered);
            openFirst = false;
        }
        if (other.gameObject.tag == "bullet2" && openFirst == true)
        {
            photonView.RPC("OpenDoor2", RpcTarget.AllBuffered);
            openFirst = false;
        }
    }
    [PunRPC]
    void OpenDoor1()
    {
        door.transform.position = new Vector3(door.transform.position.x + openDoorX, door.transform.position.y + openDoorY, door.transform.position.z);
    }
    [PunRPC]
    void OpenDoor2()
    {
        door.transform.position = new Vector3(door.transform.position.x + openDoorX, door.transform.position.y + openDoorY, door.transform.position.z);
    }
}
