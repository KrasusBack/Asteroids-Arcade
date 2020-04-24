using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarVolumeChanger : MonoBehaviour
{
    private Scrollbar scrollbar;
    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
        
    }
    public void ChangeMasterVolume()
    {
        //scrollbar.value;
    }
}
