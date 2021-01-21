using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{

    public Renderer myObject;
    public Material material1;
    public Material material2;
    public float cx=0;
    public float cy = 0;

    public void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "bullet1")
        {
            transform.position = new Vector3(transform.position.x+cx, transform.position.y+cy, 0);
            myObject.sharedMaterial = material1;
        }
        if (other.gameObject.tag == "bullet2")
        {
            transform.position = new Vector3(transform.position.x-cx, transform.position.y-cy, -1);
            myObject.sharedMaterial = material2;
        }
    }
}
