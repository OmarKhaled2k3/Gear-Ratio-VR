using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimmatorController : MonoBehaviour {
    public GameObject Recording;
    public GameObject loc;
    private ResonanceAudioSource rec;
    public Wheel wheel;
    public Buttons button;
    public Animator anim;
    public Animator anim2;
    public Image black;
    public int starts = 0;
    private int flag2 = 0;
    public GameObject gear;
    public GameObject But;
    public bool openflag = false ;
    public GameObject text;
    public GameObject shapes;
    public GameObject QA;
    public GameObject videos;
    public ReflectionProbe reflect;
    bool quizs;
    private float timer = 0;
    private float timers = 0;
    Vector3 turn;
    Vector3 turn2;
    bool buttone = false;
    bool speak = false;
    public bool open = false;
    public GameObject Arrow;
    Vector3 innovapos;
    Vector3 campos;
    Vector3 movepos;
    Vector3 InnovRot;
    void Start()
    {
        rec = GetComponent<ResonanceAudioSource>();
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        turn = new Vector3(0, -25, 0);
        turn2 = new Vector3(0, 25, 0);
    }
    void Update()
    {
        //Debug.Log(Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x);
        if (Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x > 35 && Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x < 70 && speak == false) { But.SetActive(true);
            Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
       }
        else {  if (open ) { But.SetActive(true); Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true); } else { But.SetActive(false);
                if (buttone) { Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false); }
            } 
            }
        if (openflag)
        {
            timers += Time.deltaTime;
            if (timers > 2)
            {
                open = false;
                openflag = false;
            }
        }
        else { timers = 0; }
        //Debug.Log(audioData.time);
        if(starts == 1)
        {
            audioData.Play(0);
            loc.GetComponent<Innova>().enabled = true;
            buttone = true;
            starts = 0;
            open = false;
            
            
        }
        if (starts == 2)
        {
            loc.GetComponent<Innova>().enabled = false;
        }
        innovapos = transform.localPosition;
        campos = Recording.transform.localPosition;
        movepos = loc.transform.position;
        InnovRot = transform.eulerAngles;
        //print(flag);
        if (audioData.time > 17.5 && flag == 0 && audioData.time < 18)
        {
            AnimateRaiseuphands();
        }
        if (audioData.time > 6 && flag == 0 && audioData.time<10)
        {
            AnimateIdle();
        }
        if (audioData.time > 13 && flag == 0 && audioData.time < 16)
        {
            AnimateExplainRight();
        }
        if (audioData.time > 19 && flag == 2 && audioData.time < 22)
        {
            AnimateIdle();
            if(audioData.time > 19 &&  audioData.time < 21.8f) { QA.transform.GetChild(3).gameObject.SetActive(true); }
            flag = 0;
            
        }
        if (audioData.time > 18.8 && flag == 0 && audioData.time < 19)
        {
            Debug.Log("Paused to Speak: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 1;
            speak = true;
            flag = 1;
        }
        
        if (Recording.GetComponent<RecordingCanvas>().start == 2 && flag == 1 && quizs == false) {
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            speak = false;
            flag =2; 
            print("UnPaused");
            
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 7 && flag == 1 && quizs == false)
        {
            audioData.time = 18f;  
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused");
            flag = 0;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 2 && flag == 1 && quizs)
        {
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            speak = false;
            flag = 2;

        }
        if (audioData.time > 23 && audioData.time < 24.5)
        {
            Recording.GetComponent<RecordingCanvas>().start = 3;
            QA.transform.GetChild(3).gameObject.SetActive(false);

        }
        if (audioData.time > 24.5 &&  audioData.time < 29)
        {   
            AnimateExplainRight();
            text.transform.GetChild(7).gameObject.SetActive(true);
            if(audioData.time> 26)
            {
                text.transform.GetChild(6).gameObject.SetActive(true);
            }
            
        }
        if (audioData.time > 29.2 && audioData.time < 29.3 && flag == 0)
        {
            AnimateIdle();
            text.transform.GetChild(6).gameObject.SetActive(false);
            text.transform.GetChild(7).gameObject.SetActive(false);
            Pause();
            if (loc.transform.position.z < 14.58)
            {
                loc.transform.position += 7f * Vector3.forward * Time.deltaTime;
                anim.enabled = true;

            }
            else
             {
            if (transform.eulerAngles.y > 245.5)
            { transform.Rotate(turn * Time.deltaTime * 1.2f); }
            else
            {
                flag = 2;
                wheel.rend.enabled = true;
                
            }

            }
            //loc.transform.position = new Vector3(-1.46f,loc.transform.position.y,14.58f);
            //transform.Rotate(0, -25f, 0, Space.Self);

        }
        if (audioData.time > 29 && audioData.time < 49 && flag == 2)
        {
            Unpause();
            AnimateGreet();
           if(audioData.time> 38 && audioData.time < 45)
            {
                AnimateExplainLeft();
                videos.SetActive(true);
                wheel.rend.enabled = false;
                
                   
            }
            if (audioData.time > 45 && audioData.time < 46)
            {
                AnimateIdle();
                videos.SetActive(false);
                wheel.rend.enabled = true;
            }
            
        }
        if (audioData.time > 53 && flag == 2)
        {
            wheel.AnimateExtrude();
        }
        if (audioData.time > 69 && audioData.time < 72)

        {
            wheel.rend.enabled = false;
            text.transform.GetChild(1).gameObject.SetActive(true);
            if(audioData.time > 70 ){ text.transform.GetChild(0).gameObject.SetActive(true); }

            
        }
        if (audioData.time > 72 && audioData.time < 74 && flag == 2)

        {
            if (loc.transform.position.z > 7.83)
            {
                loc.transform.position -= 7f * Vector3.forward * Time.deltaTime;
            }
            if (transform.eulerAngles.y < 270)
            { transform.Rotate(turn2 * Time.deltaTime * 1.2f); }
            text.transform.GetChild(1).gameObject.SetActive(false);
            text.transform.GetChild(0).gameObject.SetActive(false);
            AnimateIdle();
        }
        if (audioData.time > 84 && audioData.time < 85.5 )

        {
            AnimateExplainRight();
            text.transform.GetChild(2).gameObject.SetActive(true);

        }
        if (audioData.time > 85.5 && audioData.time < 86.5)

        {
            text.transform.GetChild(3).gameObject.SetActive(true);

        }
        if (audioData.time > 86.5 && audioData.time < 87)

        {
            text.transform.GetChild(4).gameObject.SetActive(true);
            AnimateExplainLeft();
        }
        if (audioData.time > 87.5 && audioData.time < 89.2)

        {
            text.transform.GetChild(5).gameObject.SetActive(true);
            if (audioData.time > 89)
            {
                AnimateIdle();
                text.transform.GetChild(5).gameObject.SetActive(false);
                text.transform.GetChild(4).gameObject.SetActive(false);
                text.transform.GetChild(3).gameObject.SetActive(false);
                text.transform.GetChild(2).gameObject.SetActive(false);
            }

        }
        if (audioData.time > 96.7 && audioData.time < 96.8 && flag == 2)
        {
            Pause();
            if (loc.transform.localPosition.x < 12.8)
            {
                if(transform.localPosition.z < -22)
                {
                    transform.localPosition += 8f * Vector3.forward * Time.deltaTime;
                }
                loc.transform.localPosition -= 5f * transform.forward * Time.deltaTime;
                if (transform.eulerAngles.y > 225.5)
                { transform.Rotate(turn * Time.deltaTime * 1.2f); }
                if (Recording.transform.position.x < 15.42) { Recording.transform.position += 5f * Recording.transform.forward * Time.deltaTime; }
            }
            else
            {
                flag = 0;

            }
        }
        //loc.transform.position = new Vector3(-1.46f,loc.transform.position.y,14.58f);
        //transform.Rotate(0, -25f, 0, Space.Self);

        if (audioData.time > 96.7 && audioData.time < 134.2 && flag == 0)
        {
            print("Here");
            AnimateExplainRight();
            Unpause();
            reflect.transform.localPosition = new Vector3(2.02f, 5.84f, -3.01f);
            if (audioData.time > 100)
            {
                gear.SetActive(true);
                gear.transform.GetChild(3).gameObject.SetActive(true);
            }
            if (audioData.time > 118 && audioData.time < 120)
            {
                Arrow.SetActive(true);
                Arrow.GetComponent<Animator>().SetBool("yes", true);
            }
            if (audioData.time > 120)
            {
                
                shapes.transform.GetChild(0).gameObject.SetActive(true);
                shapes.GetComponent<Fillamount>().gvrstatus = 2;
                shapes.transform.GetChild(1).gameObject.SetActive(true);
                text.transform.GetChild(8).gameObject.SetActive(true);
                text.transform.GetChild(9).gameObject.SetActive(true);
            }
            if (audioData.time > 125 && audioData.time < 126)
            {
                Arrow.GetComponent<Animator>().SetBool("yes", false);
                Arrow.GetComponent<Animator>().SetBool("second", true);
               
            }
            if (audioData.time > 126)
            {
                Arrow.GetComponent<Animator>().SetBool("second", false);
                Arrow.GetComponent<Animator>().SetBool("loop", true);
            }
            if (audioData.time > 132)
            {

                text.transform.GetChild(10).gameObject.SetActive(true);
                text.transform.GetChild(11).gameObject.SetActive(true);
                shapes.GetComponent<Fillamount>().gvrstatus = 1;
            }
            if (audioData.time > 134)
            {
                
                Pause();
                timer = timer + Time.deltaTime ;
                if (timer > 2)
                {
                    flag = 2;
                }
            }
        }
        if (audioData.time > 134 && audioData.time < 134.3 && flag == 2)
        {
            shapes.GetComponent<Fillamount>().gvrstatus = 3;
            reflect.transform.localPosition = new Vector3(2, reflect.transform.localPosition.y, -1.46f);
            shapes.transform.GetChild(0).gameObject.SetActive(false);
            shapes.transform.GetChild(1).gameObject.SetActive(false);
            text.transform.GetChild(8).gameObject.SetActive(false);
            text.transform.GetChild(9).gameObject.SetActive(false);
            text.transform.GetChild(10).gameObject.SetActive(false);
            text.transform.GetChild(11).gameObject.SetActive(false);
            gear.transform.GetChild(3).gameObject.SetActive(false);
            Arrow.SetActive(false);
            
            AnimateIdle();
            gear.SetActive(false);
            
            if (loc.transform.position.z > 7.83)
            {
                loc.transform.position -= 10f * Vector3.forward * Time.deltaTime;
            }
            else
            {
                if (transform.eulerAngles.y < 270)
                { transform.Rotate(turn2 * Time.deltaTime * 2f); }
                else { flag = 1; }
            }
        }
        if (audioData.time > 134 && audioData.time < 142.2 && flag == 1)
        {
            Unpause();
            AnimateIdle();
        }
        if(audioData.time > 142.6 && audioData.time < 142.8 )
        {
            Debug.Log("Here");
            Pause();
            if (loc.transform.position.z > -2.45)
            {
                loc.transform.position -= 10f * Vector3.forward * Time.deltaTime;
                Debug.Log("Here2");
            }
            else
            {
                if (transform.eulerAngles.y < 314.5)
                { transform.Rotate(turn2 * Time.deltaTime * 2f); Debug.Log("Here3"); }
                else { flag = 3; Debug.Log("Out"); Unpause(); }
            }


        }
        if (audioData.time > 142.8 && audioData.time < 199.5 && flag == 3)
        {
            if(audioData.time > 142.8 && audioData.time < 152)
            {
                Unpause();
                
            }
            reflect.transform.localPosition = new Vector3(-2.87f, reflect.transform.localPosition.y, -4.36f);
            gear.SetActive(true);
            gear.transform.GetChild(0).gameObject.SetActive(true);
            if (audioData.time > 152.2 && audioData.time < 154.2)
            {
                text.transform.GetChild(12).gameObject.SetActive(true);
                text.transform.GetChild(13).gameObject.SetActive(true);
                if (audioData.time > 154 && audioData.time < 154.1)
                {

                    timer = timer + Time.deltaTime;
                    if (timer > 2 )
                    {
                        Unpause();
                    }
                    else { Pause(); }
                }

            }
            if (audioData.time > 155.7 && audioData.time < 156.4)
            {
                text.transform.GetChild(13).gameObject.SetActive(false);
                text.transform.GetChild(14).gameObject.SetActive(true);
                text.transform.GetChild(15).gameObject.SetActive(true);
                shapes.transform.GetChild(2).gameObject.SetActive(true);
                
            }
            if (audioData.time > 156.2 && audioData.time < 157.2)
            {

                shapes.transform.GetChild(3).gameObject.SetActive(true);
                text.transform.GetChild(16).gameObject.SetActive(true);
                text.transform.GetChild(17).gameObject.SetActive(true);
                text.transform.GetChild(24).gameObject.SetActive(true);


            }
            if (audioData.time > 157.2 && audioData.time < 159.2)
            {

                shapes.transform.GetChild(4).gameObject.SetActive(true);
                text.transform.GetChild(18).gameObject.SetActive(true);
                text.transform.GetChild(19).gameObject.SetActive(true);
                text.transform.GetChild(20).gameObject.SetActive(true);
            }
            
            
           
            if (audioData.time > 161 && audioData.time < 164)
            {
                text.transform.GetChild(14).gameObject.SetActive(false);
                text.transform.GetChild(15).gameObject.SetActive(false);
                text.transform.GetChild(16).gameObject.SetActive(false);
                text.transform.GetChild(17).gameObject.SetActive(false);
                text.transform.GetChild(19).gameObject.SetActive(false);
                text.transform.GetChild(20).gameObject.SetActive(false);
                shapes.transform.GetChild(2).gameObject.SetActive(false);
                shapes.transform.GetChild(3).gameObject.SetActive(false);
                shapes.transform.GetChild(4).gameObject.SetActive(false);
                text.transform.GetChild(21).gameObject.SetActive(true);
                text.transform.GetChild(22).gameObject.SetActive(true);

            }
            if (audioData.time > 164 && audioData.time < 166)
            {
                text.transform.GetChild(25).gameObject.SetActive(true);
                shapes.transform.GetChild(5).gameObject.SetActive(true);

            }
            if (audioData.time > 166 && audioData.time < 172)
            {
                text.transform.GetChild(21).gameObject.SetActive(false);
                text.transform.GetChild(22).gameObject.SetActive(false);
                text.transform.GetChild(26).gameObject.SetActive(true);
                if (audioData.time > 168 && audioData.time < 170)
                { 
                    text.transform.GetChild(27).gameObject.SetActive(true); 
                }
                    
                if (audioData.time > 170)
                {
                    text.transform.GetChild(27).gameObject.SetActive(false);
                    text.transform.GetChild(23).gameObject.SetActive(true);
                }
            }
            if (audioData.time > 172 && audioData.time < 173)
            {
                text.transform.GetChild(25).gameObject.SetActive(false);
                shapes.transform.GetChild(5).gameObject.SetActive(false);
                text.transform.GetChild(26).gameObject.SetActive(false);
                text.transform.GetChild(23).gameObject.SetActive(false);


            }
            if (audioData.time > 174.8 && audioData.time < 175.5)
            {
                
                text.transform.GetChild(28).gameObject.SetActive(true);


            }
            if (audioData.time > 179.2 && audioData.time < 185)
            {
                text.transform.GetChild(28).gameObject.SetActive(false) ;
                text.transform.GetChild(29).gameObject.SetActive(true);
                text.transform.GetChild(30).gameObject.SetActive(true);
                if (audioData.time > 183 && audioData.time < 185)
                {
                    text.transform.GetChild(31).gameObject.SetActive(true);
                    text.transform.GetChild(32).gameObject.SetActive(true);
                }

            }
        }
        if (audioData.time > 199.5 && audioData.time < 314)
        {

            if (audioData.time > 199.5 && audioData.time < 201)
            {

                text.transform.GetChild(29).gameObject.SetActive(false);
                text.transform.GetChild(30).gameObject.SetActive(false);
                text.transform.GetChild(31).gameObject.SetActive(false);
                text.transform.GetChild(32).gameObject.SetActive(false);
                gear.transform.GetChild(0).gameObject.SetActive(false);
                gear.transform.GetChild(2).gameObject.SetActive(true);
                gear.transform.GetChild(4).gameObject.SetActive(true);
                AnimateExplainLeft();
            }
            if(audioData.time > 206 && audioData.time < 207)
            {
                gear.transform.GetChild(2).gameObject.GetComponent<Animator>().SetBool("go", true);

            }
            if (audioData.time > 207 && audioData.time < 208)
            {
                gear.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (audioData.time > 210 && audioData.time < 214)
            {
                text.transform.GetChild(33).gameObject.SetActive(true);
                if (audioData.time > 212 && audioData.time < 214)
                {
                    text.transform.GetChild(34).gameObject.SetActive(true);
                }
            }
            if (audioData.time > 214 && audioData.time < 219)
            {
                gear.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                if (audioData.time > 216.8 && audioData.time < 217)
                {
                    text.transform.GetChild(35).gameObject.SetActive(true);
                    
                    
                }
                if (audioData.time > 218 && audioData.time < 219)
                {
                    text.transform.GetChild(36).gameObject.SetActive(true);
                }
            }
            if (audioData.time > 219.5 && audioData.time < 231)
            {
                if (audioData.time > 219.5 && audioData.time < 220)
                {
                    text.transform.GetChild(33).gameObject.SetActive(false);
                    text.transform.GetChild(34).gameObject.SetActive(false);
                    text.transform.GetChild(35).gameObject.SetActive(false);
                    text.transform.GetChild(36).gameObject.SetActive(false);
                    gear.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Gear3>().enabled = true;
                    gear.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<GearRot>().enabled = true;
                }
                
                if (audioData.time > 222.5 && audioData.time < 224)
                {
                    text.transform.GetChild(37).gameObject.SetActive(true);
                    text.transform.GetChild(38).gameObject.SetActive(true);

                    
                }
                if (audioData.time > 230 && audioData.time < 231)
                {
                    text.transform.GetChild(39).gameObject.SetActive(true);
                    text.transform.GetChild(40).gameObject.SetActive(true);
                }
            }
            if (audioData.time > 234 && audioData.time < 235)
            {
                text.transform.GetChild(37).gameObject.SetActive(false);
                text.transform.GetChild(38).gameObject.SetActive(false);
                text.transform.GetChild(39).gameObject.SetActive(false);
                text.transform.GetChild(40).gameObject.SetActive(false);
            }
            if (audioData.time > 266 && audioData.time < 267)
            {
                text.transform.GetChild(41).gameObject.SetActive(true);
                
            }
            if (audioData.time > 271.5 && audioData.time < 272)
            {
                text.transform.GetChild(42).gameObject.SetActive(true);

            }
            if (audioData.time > 280 && audioData.time < 281)
            {
                text.transform.GetChild(42).gameObject.SetActive(false);
                text.transform.GetChild(41).gameObject.SetActive(false);

            }
            if (audioData.time > 297 && audioData.time < 298)
            {
                text.transform.GetChild(43).gameObject.SetActive(true);

            }
        }
        if (audioData.time > 314.5 && audioData.time < 315 && flag2 == 0)
        {
            text.transform.GetChild(43).gameObject.SetActive(false);
            gear.transform.GetChild(2).gameObject.GetComponent<Animator>().SetBool("go", false);
            gear.transform.GetChild(2).gameObject.SetActive(false);
            gear.SetActive(false);
            AnimateIdle();
            Pause();
            if (loc.transform.position.z < 7.83)
            {
                loc.transform.position += 10f * Vector3.forward * Time.deltaTime;
            }
            else
            {
                if (transform.eulerAngles.y > 270)
                { transform.Rotate(turn * Time.deltaTime * 2f); }
                else { flag2 = 1; }
            }
        }
        if (audioData.time > 314.5 && audioData.time < 326 && flag2 == 1)
        {
            text.transform.GetChild(43).gameObject.SetActive(false);
            gear.transform.GetChild(2).gameObject.GetComponent<Animator>().SetBool("go", false);
            gear.transform.GetChild(2).gameObject.SetActive(false);
            gear.SetActive(false);
            Unpause();
            AnimateRaiseuphands();
            reflect.transform.localPosition = new Vector3(2, reflect.transform.localPosition.y, -1.46f);

        }
        if (audioData.time > 326 && audioData.time < 329 && flag2 == 1)
        {
            
            
            AnimateIdle();
            if (loc.transform.position.z < 18)
            {
                loc.transform.position += 10f * Vector3.forward * Time.deltaTime;
            }
                
            else
            {
                if (transform.eulerAngles.y > 225.5)
                { transform.Rotate(turn * Time.deltaTime * 2f); }
                else { flag2 = 0; }
            }

        }
        if (audioData.time > 326 && audioData.time < 330 && flag2 == 0)
        {
            gear.transform.GetChild(1).gameObject.SetActive(false);
            gear.SetActive(true);
            gear.transform.GetChild(2).gameObject.SetActive(true);
            AnimateExplainRight();
            reflect.transform.localPosition = new Vector3(2.02f, 5.84f, -3.01f);
            
        }
        if (audioData.time > 330 && audioData.time < 335 )
        {
            gear.transform.GetChild(2).gameObject.GetComponent<Animator>().SetBool("go", true);
            if(audioData.time > 332.5) { gear.transform.GetChild(5).gameObject.SetActive(true); }
        }
        if (audioData.time > 335 && audioData.time < 339.8 )
        {
            AnimateIdle();
            QA.transform.GetChild(0).gameObject.SetActive(true);
            flag = 0;
            quizs = true;
            timer = 0;
        }
        if (audioData.time > 339.8 && audioData.time < 340 && flag == 0)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 4;
            QA.transform.GetChild(4).gameObject.SetActive(true);
            speak = true;
            flag = 1;

        }
        if (audioData.time > 339.8 && audioData.time < 340.2 && flag == 2)
        {
            timer += Time.deltaTime;
            if (Recording.GetComponent<RecordingCanvas>().answer == 1)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                QA.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;

            }
            else if (Recording.GetComponent<RecordingCanvas>().answer == 2)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(3).gameObject.SetActive(true); QA.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;
            }
           
            if (timer > 3)
            {
                flag = 3;
                Recording.GetComponent<RecordingCanvas>().start = 3;
                gear.transform.GetChild(5).gameObject.SetActive(false);
                gear.transform.GetChild(2).gameObject.SetActive(false);
                QA.transform.GetChild(0).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(3).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Unpause();
            }
            
           
           
        }
        if (audioData.time > 344 && audioData.time < 353 && flag == 3)
        {
            gear.transform.GetChild(0).gameObject.SetActive(true);
            gear.transform.GetChild(0).gameObject.GetComponent<GearRot1>().enabled = true;
            AnimateExplainRight();
            QA.transform.GetChild(1).gameObject.SetActive(true);
            flag = 0;
            timer = 0;

        }
        if (audioData.time > 354 && audioData.time < 354.2 && flag == 0)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 5;
            speak = true;
            flag = 1;
        }
        if (audioData.time > 354 && audioData.time < 355 && flag == 2)
        {
            timer += Time.deltaTime;
            
            if (Recording.GetComponent<RecordingCanvas>().answer == 1)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                QA.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;

            }
            else if (Recording.GetComponent<RecordingCanvas>().answer == 2)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(4).gameObject.SetActive(true); QA.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true; QA.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.GetComponent<Animation>().enabled = true;
            }
            if (timer > 3)
            {
                Recording.GetComponent<RecordingCanvas>().start = 3;
                AnimateIdle();
                gear.transform.GetChild(6).gameObject.SetActive(true);
                QA.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(4).gameObject.SetActive(false);
                gear.transform.GetChild(0).gameObject.SetActive(false);
                flag = 3;
                Unpause();
            }
            
        }
        if (audioData.time > 360 && audioData.time < 382 && flag == 3)
        {
            text.transform.GetChild(44).gameObject.SetActive(true);
            if (audioData.time > 364 && audioData.time < 365 )
            { text.transform.GetChild(45).gameObject.SetActive(true); }
            if(audioData.time > 369 && audioData.time < 370)
            { text.transform.GetChild(41).gameObject.SetActive(true); }
            if (audioData.time > 375 && audioData.time < 380)
            { QA.transform.GetChild(2).gameObject.SetActive(true); flag = 0; timer = 0; }

        }

        if (audioData.time > 382 && audioData.time < 382.3 && flag == 0)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 6;
            speak = true;
            flag = 1;

        }
        if (audioData.time > 382 && audioData.time < 383 && flag == 2)
        {
            timer += Time.deltaTime;

            if(timer > 3)
            {
                Recording.GetComponent<RecordingCanvas>().start = 3;

                text.transform.GetChild(41).gameObject.SetActive(false);
                text.transform.GetChild(45).gameObject.SetActive(false);
                text.transform.GetChild(44).gameObject.SetActive(false);
                gear.transform.GetChild(6).gameObject.SetActive(false);
                QA.transform.GetChild(2).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                QA.transform.GetChild(4).gameObject.transform.GetChild(5).gameObject.SetActive(false);
                flag = 3;
                Unpause();
                speak = false;
                QA.transform.GetChild(4).gameObject.SetActive(false);
            }
            if (Recording.GetComponent<RecordingCanvas>().answer == 1)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                QA.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;

            }
            else if (Recording.GetComponent<RecordingCanvas>().answer == 2)
            {
                QA.transform.GetChild(4).gameObject.transform.GetChild(5).gameObject.SetActive(true); QA.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true; QA.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Animation>().enabled = true;
            }
            

        }
        if (audioData.time > 382  && flag == 3)
        {
            if (loc.transform.position.z > 7.83)
            {
                loc.transform.position -= 10f * Vector3.forward * Time.deltaTime;
            }

            if (transform.eulerAngles.y < 270)
            { transform.Rotate(turn2 * Time.deltaTime * 2f); }
            else
            {
                if (audioData.time > 388)
                { AnimateBye(); }
                else { AnimateWelcome(); }
            }
                
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 8 && flag == 1)
        {
            audioData.time = 339.7f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 0;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 9 && flag == 1)
        {
            audioData.time = 353.8f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 0;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 10 && flag == 1)
        {
            audioData.time = 381.9f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 0;
        }

        if (Input.GetKey("left"))
        {
            //Pause();
            //Debug.Log("Pause: " + audioData.time);
            Recording.GetComponent<RecordingCanvas>().start = 2;
        }
        /*
        if (Input.GetKey("left"))
        {
            //Pause();
            //Debug.Log("Pause: " + audioData.time);
            Recording.GetComponent<RecordingCanvas>().start = 2;
        }
        if (Input.GetKey("right"))
        {
            //Unpause();
            //Debug.Log("Pause: " + audioData.time);
            Scene1();
            //Recording.GetComponent<RecordingCanvas>().start = 8;
        }
        if (Input.GetKey("up"))
        {
            //Recording.GetComponent<RecordingCanvas>().start = 9;
            Scene2();
        }
        if (Input.GetKey("down"))
        {
            //Recording.GetComponent<RecordingCanvas>().start = 10;
            //Recording.GetComponent<RecordingCanvas>().flag = 0;
            Scene3();
        }
        if (Input.GetKey("d"))
        {
            //Recording.GetComponent<RecordingCanvas>().start = 2;
            //Recording.GetComponent<RecordingCanvas>().flag = 0;
            Scene4();
        }
        if (Input.GetKey("c"))
        {
            Recording.GetComponent<RecordingCanvas>().answer = 1;
            //Recording.GetComponent<RecordingCanvas>().flag = 0;
            
        }
        if (Input.GetKey("w"))
        {
            Recording.GetComponent<RecordingCanvas>().answer = 2;
            //Recording.GetComponent<RecordingCanvas>().flag = 0;

        }
        */
    }
    IEnumerator Example()
    {
        Pause();
        yield return new WaitForSeconds(5);
        Unpause();
    }
    
    #region Attribute
    private Animator animator;
    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string BYE_ANIMATION_BOOL = "bye";
    private const string WELCOME_ANIMATION_BOOL = "greet";
    private const string GREET_ANIMATION_BOOL = "greet 2";
    private const string EXPLAIN_RIGHT_ANIMATION_BOOL = "Exp right";
    private const string EXPLAIN_LEFT_ANIMATION_BOOL = "Exp left";
    private const string RAISE_UP_HANDS_ANIMATION_BOOL = "Raise Both";
    #endregion
    // Use this for initialization
    AudioSource audioData;
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
    public void AnimateBye()
    {
        Animate(BYE_ANIMATION_BOOL);
    }
    #endregion
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator,boolName);
        animator.SetBool(boolName, true);
    }
    // Update is called once per frame
    public void Unpause()
    {
        
        audioData.UnPause();
    }
    public void Pause()
    {
        audioData.Pause();
    }
    public void Sections()
    {
        But.transform.GetChild(3).gameObject.SetActive(true);
        button.Animates();
        open = true;
    }
    public void InvSections()
    {
        //But.transform.GetChild(3).gameObject.SetActive(true);
        button.invAnimates();
        open = true;
        openflag = true;
    }
    public void Scene1() 
    {
        Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        movepos.x = 12.8f;
        movepos.z = 17.9f;
        innovapos.z = -20f;
        innovapos.x = 12.7f;
        innovapos.y = 1.52f;
        campos.x = 15.42f;
        InnovRot.y = 225.5f;
        loc.transform.localPosition = movepos;
        transform.localPosition = innovapos;
        Recording.transform.position = campos;
        anim.enabled = true;
        transform.eulerAngles=InnovRot;
        audioData.Play(0);
        audioData.time = 96.5f;
        AnimateIdle();
        //Unpause();
        flag = 0;
        InvSections();
        disable();
        buttone = true;
    }
    public void Scene2()
    {
        Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        movepos.x = 12.8f;
        movepos.z = -2.5f;
        innovapos.z = -20f;
        innovapos.x = 12.7f;
        innovapos.y = 1.52f;
        campos.x = 15.42f;
        InnovRot.y = 314.5f;
        loc.transform.localPosition = movepos;
        transform.localPosition = innovapos;
        Recording.transform.position = campos;
        anim.enabled = true;
        transform.eulerAngles = InnovRot;
        audioData.Play(0);
        audioData.time = 142.8f;
        //Unpause();
        flag = 3;
        InvSections();
        disable();
        buttone = true;
        AnimateIdle();

    }
    public void Scene3()
    {
        Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        movepos.x = 12.8f;
        movepos.z = -2.5f;
        innovapos.z = -20f;
        innovapos.x = 12.7f;
        innovapos.y = 1.52f;
        campos.x = 15.42f;
        InnovRot.y = 314.5f;
        loc.transform.localPosition = movepos;
        transform.localPosition = innovapos;
        Recording.transform.position = campos;
        anim.enabled = true;
        transform.eulerAngles = InnovRot;
        audioData.Play(0);
        audioData.time = 200f;
        //Unpause();
        InvSections();
        disable();
        buttone = true;
        AnimateExplainLeft();
    }
    public void Scene4()
    {
        Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        movepos.x = 12.8f;
        movepos.z = 7.83f;
        innovapos.z = -20f;
        innovapos.x = 12.7f;
        innovapos.y = 1.52f;
        campos.x = 15.42f;
        InnovRot.y = 270f;
        loc.transform.localPosition = movepos;
        transform.localPosition = innovapos;
        Recording.transform.position = campos;
        anim.enabled = true;
        transform.eulerAngles = InnovRot;
        audioData.Play(0);
        audioData.time = 314.5f;
        //Unpause();
        InvSections();
        flag2 = 1;
        disable();
        buttone = true;
    }
    public void disable()
    {
       
        for (int i = 0; i < text.transform.childCount; i++)
        {
            var child = text.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        for (int m = 0; m < gear.transform.childCount; m++)
        {
            var child = gear.transform.GetChild(m).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        for (int n = 0; n < shapes.transform.childCount; n++)
        {
            var child = shapes.transform.GetChild(n).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        for (int s = 0; s < QA.transform.childCount; s++)
        {
            var child = QA.transform.GetChild(s).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        Recording.GetComponent<GameController>().reticlePointer.SetActive(false);
        Recording.GetComponent<GameController>().canvas.SetActive(false);
    }

}
