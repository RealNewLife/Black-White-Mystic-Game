using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puzzle4 : MonoBehaviour
{
    PhotonView photonView;
    public GameObject Door;
    public Transform[] pos;

    public float speed;
    int i = 1;
    bool check = true;

    bool final = false;
    private void Awake()
    {
        photonView = PhotonView.Get(this);
    }
    private void Update()
    {
        if (i != 9)
        {
            if (final == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos[i].position, speed * Time.deltaTime);
            }

            if (transform.position == pos[i].position)
            {
                if (i == 0)
                {
                    check = true;
                }
                if (check == true)
                {
                    i++;
                }
                else
                {
                    i--;
                }
            }
        }
        else
        {
            photonView.RPC("RPCPuzzle4Door", RpcTarget.AllBuffered);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="box")
        {
            if(check == true)
            {
                check = false;
                i--;

            }
            else
            {
                check = true;
                i++;

            }
        }
    }
    [PunRPC]
    void RPCPuzzle4Door()
    {
        Door.SetActive(false);
    }
}
