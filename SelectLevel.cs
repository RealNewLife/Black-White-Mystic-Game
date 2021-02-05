using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public Button[] levelButtom;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for(int i = 0; i < levelButtom.Length; i++)
        {
            if(i+1>levelReached)
            levelButtom[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
