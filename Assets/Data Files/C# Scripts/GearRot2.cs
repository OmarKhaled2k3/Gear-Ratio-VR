using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRot2 : MonoBehaviour
{
    Vector3 turn;
    Vector3 turn2;
    // Start is called before the first frame update
    public GameObject shaft;
    void Start()
    {
        turn = new Vector3(0, 40, 0);
        turn2 = new Vector3(80, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turn * Time.deltaTime * 2f);
        shaft.transform.Rotate(turn2 * Time.deltaTime * 2f);
        if (transform.eulerAngles.y >358) { turn = new Vector3(0, 0, 0); }
        print(transform.eulerAngles.y);
    }
}
