using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puzzle1 : MonoBehaviour {
    private PhotonView photonView;
    public Button1 button1;
    public Button2 button2;
    public Button3 button3;
    public Button4 button4;
    public Transform[] door;
    public bool x1,x2,x3,x4;
    public int[] number = { 0, 0, 0, 0 };
    private int rtx3080ti;
    public void Awake()
    {
        photonView = PhotonView.Get(this);
        button1 = FindObjectOfType<Button1>();
        button2 = FindObjectOfType<Button2>();
        button3 = FindObjectOfType<Button3>();
        button4 = FindObjectOfType<Button4>();
    }

    public void Update()
    {
        if (button1.x == true)
        {
            if (number[0] <= 0)
            {
                number[0] = 3;
            }
            else
            {
                number[0] = -3;
            }
            if (number[1] <= 0)
            {
                number[1] = 3;
            }
            else
            {
                number[1] = -3;
            }

            if (number[3] <= 0)
            {
                number[3] = 3;
            }
            else
            {
                number[3] = -3;
            }
            
            rtx3080ti = number[2];
            number[2] = 0;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered,number[0],number[1],number[2],number[3],rtx3080ti);
            photonView.RPC("Puzzle1OpenDoor", RpcTarget.AllBuffered);
            number[2] = rtx3080ti;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("PuzzleX4", RpcTarget.AllBuffered);
            x1 = false;
            button1.SetX();

        }
        if (button2.x == true)
        {
            if (number[0] <= 0)
            {
                number[0] = 3;
            }
            else
            {
                number[0] = -3;
            }
            if (number[1] <= 0)
            {
                number[1] = 3;
            }
            else
            {
                number[1] = -3;
            }
            if (number[2] <= 0)
            {
                number[2] = 3;
            }
            else
            {
                number[2] = -3;
            }
            rtx3080ti = number[3];
            number[3] = 0;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("Puzzle1OpenDoor", RpcTarget.AllBuffered);
            number[3] = rtx3080ti;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("PuzzleX2", RpcTarget.AllBuffered);
            x2 = false;
            button2.SetX();

        }

        if (button3.x == true)
        {
            if (number[1] <= 0)
            {
                number[1] = 3;
            }
            else
            {
                number[1] = -3;
            }
            if (number[2] <= 0)
            {
                number[2] = 3;
            }
            else
            {
                number[2] = -3;
            }
            if (number[3] <= 0)
            {
                number[3] = 3;
            }
            else
            {
                number[3] = -3;
            }
            rtx3080ti = number[0];
            number[0] = 0;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("Puzzle1OpenDoor", RpcTarget.AllBuffered);
            number[0] = rtx3080ti;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("PuzzleX3", RpcTarget.AllBuffered);
            button3.SetX();

        }

        if (button4.x == true)
        {
            if (number[0] <= 0)
            {
                number[0] = 3;
            }
            else
            {
                number[0] = -3;
            }
            if (number[2] <= 0)
            {
                number[2] = 3;
            }
            else
            {
                number[2] = -3;
            }
            if (number[3] <= 0)
            {
                number[3] = 3;
            }
            else
            {
                number[3] = -3;
            }
            rtx3080ti = number[1];
            number[1] = 0;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("Puzzle1OpenDoor", RpcTarget.AllBuffered);
            number[1] = rtx3080ti;
            photonView.RPC("PuzzleNumber", RpcTarget.AllBuffered, number[0], number[1], number[2], number[3], rtx3080ti);
            photonView.RPC("PuzzleX4", RpcTarget.AllBuffered);
            button4.SetX();

        }
    }
    [PunRPC]
    void Puzzle1OpenDoor()
    {
        door[0].transform.position = new Vector3(door[0].transform.position.x, door[0].transform.position.y + number[0], door[0].transform.position.z);
        door[1].transform.position = new Vector3(door[1].transform.position.x, door[1].transform.position.y + number[1], door[1].transform.position.z);
        door[2].transform.position = new Vector3(door[2].transform.position.x, door[2].transform.position.y + number[2], door[2].transform.position.z);
        door[3].transform.position = new Vector3(door[3].transform.position.x, door[3].transform.position.y + number[3], door[3].transform.position.z);
    }

    [PunRPC]
    void PuzzleX1()
    {
        x1 = false;
    }
    [PunRPC]
    void PuzzleX2()
    {
        x2 = false;
    }
    [PunRPC]
    void PuzzleX3()
    {
        x3 = false;
    }
    [PunRPC]
    void PuzzleX4()
    {
        x4 = false;
    }
    [PunRPC]
    void PuzzleNumber(int x,int x1,int x2, int x3,int rtx)
    {
        number[0] = x;
        number[1] = x1;
        number[2] = x2;
        number[3] = x3;
        rtx3080ti = rtx;
    }
}
