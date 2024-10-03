using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    Vector3 turnwheel;
    public SkinnedMeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        rend.enabled = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        turnwheel = new Vector3(0, 0, -45);
        transform.Rotate(turnwheel * Time.deltaTime * 1.5f);
        //if(time.GetComponent<PlayerAnimmatorController>().audioData > 5)
        //{ print("yes"); }
    }
    private Animator animator;
    public void AnimateExtrude()
    {
        animator.SetBool("Extrude", true);
    }
   
}
