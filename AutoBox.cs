using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoBox : MonoBehaviour
{
    public Renderer myObject;
    public Material material1;
    public Material material2;
    public float timeSetWhile = 2;
    public float timeSetBlack = 2;
    public bool firstSet = true;
    private void Awake()
    {
        if (firstSet == true)
        {
            StartCoroutine(WhileTimer());

        }
        else
        {
            StartCoroutine(BlackTimer());
 
        }
        
    }
    void Update()
    {
    }
    public IEnumerator WhileTimer()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        myObject.sharedMaterial = material1;
        yield return new WaitForSeconds(timeSetWhile);
        StartCoroutine(BlackTimer());
    }
    public IEnumerator BlackTimer()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        myObject.sharedMaterial = material2;
        yield return new WaitForSeconds(timeSetBlack);
        StartCoroutine(WhileTimer());
    }


}
