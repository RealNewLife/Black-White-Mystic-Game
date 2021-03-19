using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puzzle3 : MonoBehaviour
{
    PhotonView photonView;
    public BossFinal bossFinal;
    public Renderer[] Rbutton;
    public ButtonPuzzle3 button;
    public ButtonPuzzle31 button1;
    public ButtonPuzzle32 button2;
    public ButtonPuzzle33 button3;
    public ButtonPuzzle34 button4;
    public ButtonPuzzle35 button5;
    public ButtonPuzzle36 button6;
    public ButtonPuzzle37 button7;
    public ButtonPuzzle38 button8;
    public ButtonPuzzle39 button9;
    public bool x;
    public Material materialWhite;
    public Material materialBlack;
    public float timeSetWhile;
    public float timeSetBlack;
    public int[] randomNumber; 
    public int[] numberCheck;
    private int i = 0;
    public int k = 0;
    private bool reSetNumber = false;
    public bool lockNumber = false;
    public int j = 4;

    private void Awake()
    {
        bossFinal = FindObjectOfType<BossFinal>();
        photonView = PhotonView.Get(this);
        button = FindObjectOfType<ButtonPuzzle3>();
        button1 = FindObjectOfType<ButtonPuzzle31>();
        button2 = FindObjectOfType<ButtonPuzzle32>();
        button3 = FindObjectOfType<ButtonPuzzle33>();
        button4 = FindObjectOfType<ButtonPuzzle34>();
        button5 = FindObjectOfType<ButtonPuzzle35>();
        button6 = FindObjectOfType<ButtonPuzzle36>();
        button7 = FindObjectOfType<ButtonPuzzle37>();
        button8 = FindObjectOfType<ButtonPuzzle38>();
        button9 = FindObjectOfType<ButtonPuzzle39>();
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < randomNumber.Length; i++)
            {
                randomNumber[i] = Random.Range(0, randomNumber.Length);
            }
            photonView.RPC("RPCrandomPuzzle3", RpcTarget.AllBuffered, randomNumber);
        }
        
        StartCoroutine(BlackTimer(Rbutton, randomNumber));
        
    }

    
    public void Update()
    {
        if (button.x == true && lockNumber == false)
        {
            numberCheck[k] = button.buttonNumber;
            button.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button1.x == true && lockNumber == false)
        {
            numberCheck[k] = button1.buttonNumber;
            button1.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }

        }
        if (button2.x == true && lockNumber == false)
        {
            numberCheck[k] = button2.buttonNumber;
            button2.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button3.x == true && lockNumber == false)
        {
            numberCheck[k] = button3.buttonNumber;
            button3.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }       
        if (button4.x == true && lockNumber == false)
        {

            numberCheck[k] = button4.buttonNumber;
            button4.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button5.x == true && lockNumber == false)
        {

            numberCheck[k] = button5.buttonNumber;
            button5.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button6.x == true && lockNumber == false)
        {

            numberCheck[k] = button6.buttonNumber;
            button6.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button7.x == true && lockNumber == false)
        {

            numberCheck[k] = button7.buttonNumber;
            button7.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button8.x == true && lockNumber == false)
        {

            numberCheck[k] = button8.buttonNumber;
            button8.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if (button9.x == true && lockNumber == false)
        {

            numberCheck[k] = button9.buttonNumber;
            button9.SetX();
            if (randomNumber[k] == numberCheck[k])
            {
                k++;
            }
            else
            {
                k = 0;
                reSetNumber = true;
            }
        }
        if(reSetNumber == true)
        {

            for(int i = 0; i < numberCheck.Length; i++)
            {
                numberCheck[i] = 0;
            }
            reSetNumber = false;
        }
        if (k == j && lockNumber == false)
        {
            Debug.Log("steee");
            j = j + 2;
            k = 0;
            random();

            photonView.RPC("RPCStageBoss", RpcTarget.AllBuffered);
            if (bossFinal.stage == 2)
            {
                bossFinal.AttackBoss = 5;
            }
                if (j > 8)
            {
                lockNumber = true;
            }
        }
    }
    public void random()
    {
            for (int i = 0; i < randomNumber.Length; i++)
            {
                randomNumber[i] = Random.Range(0, randomNumber.Length);
            }
            photonView.RPC("RPCrandomPuzzle3", RpcTarget.AllBuffered, randomNumber);
    }
    public IEnumerator WhiteTimer(Renderer[] R123, int randomN)
    {
        R123[randomN].sharedMaterial = materialWhite;

        yield return new WaitForSeconds(timeSetBlack);

    }
    public IEnumerator BlackTimer(Renderer[] R123, int[] randomN)
    {

        for (int i = 0; i < j; i++)
        {
            R123[randomN[i]].sharedMaterial = materialBlack;

            yield return new WaitForSeconds(timeSetWhile);
            StartCoroutine(WhiteTimer(Rbutton, randomN[i]));
            yield return new WaitForSeconds(timeSetWhile);
        }
        StartCoroutine(Waite3Second());
    }
    public IEnumerator Waite3Second()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(BlackTimer(Rbutton, randomNumber));
    }
    [PunRPC]
    void RPCrandomPuzzle3(int[] a)
    {
        randomNumber = a;
    }
    [PunRPC]
    void RPCStageBoss()
    {
        bossFinal.stage++;
    }
}
