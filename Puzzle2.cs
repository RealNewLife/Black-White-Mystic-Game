using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puzzle2 : MonoBehaviour
{
    PhotonView photonView;
    public ButtonPuzzle2 buttonPuzzle;
    public ButtonPuzzle21 buttonPuzzle1;
    public ButtonPuzzle22 buttonPuzzle2;
    public ButtonPuzzle23 buttonPuzzle3;
    public Transform triangle;
    public Transform triangle1;
    public Transform triangle2;
    public Transform triangle3;
    public Transform doorOpen;
    public bool x1,x2,x3,x4;
    public float rotationTriangle;
    public float rotationTriangle1;
    public float rotationTriangle2;
    public float rotationTriangle3;
    public int successPuzzle1=0;
    public int successPuzzle2=1;
    public int successPuzzle3=2;
    public int successPuzzle4=3;
    public bool lookTriang = false;
    void Start()
    {
        photonView = PhotonView.Get(this);
        buttonPuzzle = FindObjectOfType<ButtonPuzzle2>();
        buttonPuzzle1 = FindObjectOfType<ButtonPuzzle21>();
        buttonPuzzle2 = FindObjectOfType<ButtonPuzzle22>();
        buttonPuzzle3 = FindObjectOfType<ButtonPuzzle23>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPuzzle.x== true&& lookTriang == false)
        {
            Debug.Log("Test");
            rotationTriangle = 90;
            rotationTriangle1= 90;
            rotationTriangle2= 90;
            rotationTriangle3= 0;
            successPuzzle1 += 1;
            successPuzzle2 += 1;
            successPuzzle3 += 1;
            successPuzzle4 += 0;
    photonView.RPC("RPCPuzzle2", RpcTarget.AllBuffered);
            x1 = false;
            buttonPuzzle.SetX();
        }
        if (buttonPuzzle1.x == true && lookTriang == false)
        {
            Debug.Log("Test1");
            rotationTriangle = 0;
            rotationTriangle1 = 90;
            rotationTriangle2 = 90;
            rotationTriangle3 = 90;
            successPuzzle1 += 0;
            successPuzzle2 += 1;
            successPuzzle3 += 1;
            successPuzzle4 += 1;
            photonView.RPC("RPCPuzzle2", RpcTarget.AllBuffered);
            x1 = false;
            buttonPuzzle1.SetX();
        }
        if (buttonPuzzle2.x == true && lookTriang == false)
        {
            Debug.Log("Test2");
            rotationTriangle = 90;
            rotationTriangle1 = 0;
            rotationTriangle2 = 90;
            rotationTriangle3 = 90;
            successPuzzle1 += 1;
            successPuzzle2 += 0;
            successPuzzle3 += 1;
            successPuzzle4 += 1;
            photonView.RPC("RPCPuzzle2", RpcTarget.AllBuffered);
            x1 = false;
            buttonPuzzle2.SetX();
        }
        if (buttonPuzzle3.x == true && lookTriang == false)
        {
            Debug.Log("Test3");
            rotationTriangle = 90;
            rotationTriangle1 = 90;
            rotationTriangle2 = 0;
            rotationTriangle3 = 90;
            successPuzzle1 += 1;
            successPuzzle2 += 1;
            successPuzzle3 += 0;
            successPuzzle4 += 1;
            photonView.RPC("RPCPuzzle2", RpcTarget.AllBuffered);
            x1 = false;
            buttonPuzzle3.SetX();
        }
        if(successPuzzle1%4 == 2&& successPuzzle2 % 4==3&& successPuzzle3 % 4==0&& successPuzzle4 % 4 == 1 && lookTriang == false)
        {
            photonView.RPC("RPCPuzzle2OpenDoor", RpcTarget.AllBuffered);
            lookTriang = true;
        }
    }
    [PunRPC]
    void RPCPuzzle2()
    {
        triangle.Rotate(0, 0, triangle.rotation.z + rotationTriangle);
        triangle1.Rotate(0, 0, triangle.rotation.z + rotationTriangle1);
        triangle2.Rotate(0, 0, triangle.rotation.z + rotationTriangle2);
        triangle3.Rotate(0, 0, triangle.rotation.z + rotationTriangle3);
    }
    [PunRPC]
    void RPCPuzzle2OpenDoor()
    {
        doorOpen.transform.position = new Vector3(doorOpen.transform.position.x, doorOpen.transform.position.y + 3, doorOpen.transform.position.z);
    }

}
