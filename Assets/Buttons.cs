using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Animator animator;
    public GameObject script;
    public void Animates()
    {
        animator.SetBool("sect", true);
        animator.SetBool("inv", false);
    }
    public void invAnimates()
    {
        script.GetComponent<GVRTimerScript>().gvrstatus = false;
        script.GetComponent<GVRTimerScript>().gvrtimer = 0;
        script.GetComponent<GVRTimerScript>().img.fillAmount = 0;
        animator.SetBool("sect", false);
        animator.SetBool("inv", true);
    }
}
