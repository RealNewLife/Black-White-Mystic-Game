using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw1 : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public float posDraw;
    LineRenderer currentLineRenderer;

    Vector3 lastPos;
    bool activeSkill = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            activeSkill = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            activeSkill = false;
        }
        if(activeSkill == true)
        {
            Drawing();
        }
    }
    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        //because you gotta have 2 points to start a line renderer, 
        Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = posDraw;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector3 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        pointPos.z = posDraw;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

}
