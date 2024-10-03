using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Innova;
    public float speed = 3f;
    public PlayerAnimmatorController animate;
    public GameObject canvas;
    public GameObject reticlePointer;
    // Start is called before the first frame update
    private int flag = 0;
    Vector3 turn;
    void Start()
    {
        turn = new Vector3(0,45,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // close icon pressed, place appropriate code here
            Application.Quit();
        }
        if (flag == 1)
        {
            Innova.GetComponent<PlayerAnimmatorController>().starts = 2;
            canvas.SetActive(false);
            if (transform.position.x < 0) { transform.position += speed * transform.forward * Time.deltaTime; }

            print(Innova.transform.eulerAngles.y);
            if (Innova.transform.position.y > 1)
            {
                Innova.transform.position += speed * Vector3.down * Time.deltaTime;
                print("Flag = 0");
                //if (Innova.transform.position.y < 4)
                //{
                   
                    // Quaternion.Euler(0, 45, 0) * Vector3.forward
               // }

            }
            else {
                if (Innova.transform.position.z > -12.66)
                {
                    Innova.transform.position -= 10f * Vector3.forward * Time.deltaTime;
                     
                    
                }
                else { if (Innova.transform.eulerAngles.y <270) { Innova.transform.Rotate(turn * Time.deltaTime * 2f); } else { animate.AnimateWelcome(); reticlePointer.SetActive(false);
                        Innova.GetComponent<PlayerAnimmatorController>().starts = 1; flag = 2; } }
                    
            }

        }
        #region InputtoAnimate

        if (Input.GetKey("d"))
        {
            animate.AnimateExplainRight();
        }
        if (Input.GetKey("w"))
        {
            animate.AnimateRaiseuphands();
        }
        if (Input.GetKey("s"))
        {
            animate.AnimateGreet();
        }
        
        if (Input.GetKey("space"))
        {
            animate.AnimateWelcome();
        }
        
        if (Input.GetKey("a"))
        {
            animate.AnimateExplainLeft();
        }
        if (Input.GetKey("e"))
        {
            animate.AnimateIdle();
        }

        #endregion



    }
    public void Func()
    {
        flag = 1;
        
        //else { flag = false; }
    }
    
}
