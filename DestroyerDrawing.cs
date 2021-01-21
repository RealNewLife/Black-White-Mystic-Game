using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerDrawing : MonoBehaviour
{
    private float timeDelay;
    void Start()
    {
        timeDelay = Time.time + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true)
        {
            timeDelay = Time.time + 5f;
        }
        else
        {
            if(Time.time > timeDelay)
            {
                Destroy(gameObject);

            }
        }
    }
}
