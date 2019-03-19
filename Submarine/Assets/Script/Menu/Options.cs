using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject panel;
    public void OpenPanel()
    {
        if (panel !=null)
        {
            panel.SetActive(true);
        }
    }
    
}
