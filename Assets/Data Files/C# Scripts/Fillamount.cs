using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fillamount : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;
    public Image img2;
    float totaltime = 2;
    public int gvrstatus = 0;
    float gvrtimer;
    float gvrtimer2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrstatus == 2) { gvrtimer = gvrtimer + Time.deltaTime; img.fillAmount = gvrtimer / totaltime; }
        else if (gvrstatus == 1) { gvrtimer2 = gvrtimer2 + Time.deltaTime; img2.fillAmount = gvrtimer2 / totaltime; }
        else if(gvrstatus == 3) { gvrtimer = 0; gvrtimer2 = 0; img2.fillAmount = 0; img.fillAmount = 0; }
    }
}
