using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {
    public GameObject loc;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        loc.transform.position = new Vector3(-1.46f, loc.transform.position.y, 7.83f);



    }
    #region Attribute
    private Animator animator;
    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string WELCOME_ANIMATION_BOOL = "greet";
    private const string GREET_ANIMATION_BOOL = "greet 2";
    private const string EXPLAIN_RIGHT_ANIMATION_BOOL = "Exp right";
    private const string EXPLAIN_LEFT_ANIMATION_BOOL = "Exp left";
    private const string RAISE_UP_HANDS_ANIMATION_BOOL = "Raise Both";
    #endregion
    // Use this for initialization
    
    private int flag = 0;
    
    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
            if(parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
    #region Animate Functions
    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }
    public void AnimateWelcome()
    {
        Animate(WELCOME_ANIMATION_BOOL);
    }
    public void AnimateGreet()
    {
        Animate(GREET_ANIMATION_BOOL);
    }
    public void AnimateExplainRight()
    {
        Animate(EXPLAIN_RIGHT_ANIMATION_BOOL);
    }
    public void AnimateExplainLeft()
    {
        Animate(EXPLAIN_LEFT_ANIMATION_BOOL);
    }
    public void AnimateRaiseuphands()
    {
        Animate(RAISE_UP_HANDS_ANIMATION_BOOL);
    }
   
    #endregion
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator,boolName);
        animator.SetBool(boolName, true);
    }
    // Update is called once per frame
    
}
