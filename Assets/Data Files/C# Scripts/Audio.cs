using UnityEngine;

// The Audio Source component has an AudioClip option.  The audio
// played in this example comes from AudioClip and is called audioData.

[RequireComponent(typeof(AudioSource))]
public class ExampleScript : MonoBehaviour
{
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }

    void Update()
    {
        if (Input.GetKey("left"))
        {
            audioData.Pause();
            Debug.Log("Pause: " + audioData.time);
        }

        if (Input.GetKeyDown("space"))
        {
            audioData.UnPause();
        }
    }
}