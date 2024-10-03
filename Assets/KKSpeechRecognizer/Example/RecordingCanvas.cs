using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using KKSpeech;
using ArabicSupport;

public class RecordingCanvas : MonoBehaviour
{

    public bool startRecordingButton;
    public Text resultText;
    public TextMesh quiz;
    public int start = 0;
    public int flag = 0;
    public int answer = 0;
    public bool er;
    void Start()
    {
        if (SpeechRecognizer.ExistsOnDevice())
        {
            SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
            listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
            listener.onAvailabilityChanged.AddListener(OnAvailabilityChange);
            listener.onErrorDuringRecording.AddListener(OnError);
            listener.onErrorOnStartRecording.AddListener(OnError);
            listener.onFinalResults.AddListener(OnFinalResult);
            //listener.onPartialResults.AddListener(OnPartialResult);
            listener.onEndOfSpeech.AddListener(OnEndOfSpeech);
            startRecordingButton = false;
            SpeechRecognizer.RequestAccess();
            SpeechRecognizer.SetDetectionLanguage("ar-EG");
        }
        else
        {
            resultText.text = "Sorry, but this device doesn't support speech recognition";
            startRecordingButton = false;
            transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

    /*
    public void OnFinalResult(string result)
    {

        if (result == "اتحرك" || result == "يتحرك" || result == "تحرك")
        {
            resultText.text = ArabicFixer.Fix("حاضر");
        }
        else
        {
            resultText.text = ArabicFixer.Fix(result);
            start = 2;
            startRecordingButton = false;
        }
    }
    */
    
    public void Update()
    {
       
        if(start is 0) 
        {
            SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
            listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
        }
        //print(start);
        if (start is 1 && flag == 0)
        {
            startRecordingButton = true;
            OnStartRecordingPressed();
            flag = 1;
        }
        if(start is 4 && flag == 0)
        {
            startRecordingButton = true;
            OnStartRecordingPressed();
            flag = 1;
            answer = 0;
        }
        if (start is 5 && flag == 0)
        {
            startRecordingButton = true;
            OnStartRecordingPressed();
            flag = 1;
            answer = 0;
        }
        if (start is 6 && flag == 0)
        {
            startRecordingButton = true;
            OnStartRecordingPressed();
            flag = 1;
            answer = 0;
        }
        if (start is 3)
        {
            resultText.text = " ";
            start = 2;
            transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        
    }
    public void OnFinalResult(string result)
    {
        if (start is 1)
        {
            quiz.text = ArabicFixer.Fix(result);
            start = 2;
            SpeechRecognizer.StopIfRecording();
            flag = 0;
        }
        if(start is 4 && flag == 1) {
            bool a = result.Contains("2");
            if (result == "اثنين" || result == "رقم اثنين" || a || result == "الأحمر")
            {
                //resultText.text = ArabicFixer.Fix("إجابة صحيحة");
                start = 2;
                SpeechRecognizer.StopIfRecording();
                answer = 1;
                flag = 0;
            }
            else{ //resultText.text = ArabicFixer.Fix("إجابة خاطئة");
                start = 2; flag = 0; answer = 2; }
        }

        if (start is 5 && flag == 1)
        {
            bool c = result.Contains("1");
            if (result == "واحد" || result == "رقم واحد" || c || result == "عدد الاسنان")
            {
                //resultText.text = ArabicFixer.Fix("إجابة صحيحة");
                start = 2;
                SpeechRecognizer.StopIfRecording();
                answer = 1;
                flag = 0;
            }
            else { //resultText.text = ArabicFixer.Fix("إجابة خاطئة"); 
                start = 2; flag = 0; answer = 2; }
        }
        if (start is 6 && flag == 1)
        {
            bool d = result.Contains("3");
            if (result == "ثلاثة" || result == "رقم ثلاثة" || d || result == "ثلاثين")
            {
                //resultText.text = ArabicFixer.Fix("إجابة صحيحة");
                start = 2;
                SpeechRecognizer.StopIfRecording();
                answer = 1;
                flag = 0;
            }
            else { //resultText.text = ArabicFixer.Fix("إجابة خاطئة");
                start = 2; flag = 0; answer = 2; }
        }
        if (start is 3)
        {
            resultText.text = " ";
            quiz.text = " ";
            transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);

        }
    }

    public void OnAvailabilityChange(bool available)
    {
        startRecordingButton = available;
        if (!available)
        {
            resultText.text = "Speech Recognition not available";
        }
        else
        {
            //resultText.text = "Say something :-)";
        }
    }

    public void OnAuthorizationStatusFetched(AuthorizationStatus status)
    {
        switch (status)
        {
            case AuthorizationStatus.Authorized:
                //startRecordingButton = true;
                resultText.text = " ";
                break;
            default:
                startRecordingButton = false;
                resultText.text = "Cannot use Speech Recognition, authorization status is " + status;
                transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    public void OnEndOfSpeech()
    {
        //resultText.text = "Finished";
        er = false;
    }

    public void OnError(string error)
    {
        bool b = error.Contains("6");
        //Debug.LogError(error);
        
        if ( flag == 1)
        {

            //startRecordingButton = true;
            //resultText.text = "Restarting" + error;
            if(start == 1) {
                er = true;
                start = 7;
                Debug.LogError("Restarting 7");
                flag = 0;
            }
            if (start == 4)
            {
                er = true;
                start = 8;
                Debug.LogError("Restarting 4");
                flag = 0;
            }
            else if (start == 5)
            {
                er = true;
                start = 9;
                Debug.LogError("Restarting 5");
                flag = 0;
            }
            else if (start == 6)
            {
                er = true;
                start = 10;
                Debug.LogError("Restarting 6");
                flag = 0;
            }
        }
        else { resultText.text = "Condition" + error; transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true); }
        //resultText.text = "Error" + error;

    }
    public void OnStartRecordingPressed()
    {
        if (SpeechRecognizer.IsRecording() && er == false)
        {
            SpeechRecognizer.StopIfRecording();
            //startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording";
        }
        else if (SpeechRecognizer.IsRecording() && er)
        {
            SpeechRecognizer.StopIfRecording();
            SpeechRecognizer.StartRecording(true);
            //startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording";
        }
        else
        {
            SpeechRecognizer.StartRecording(true);
            //startRecordingButton.GetComponentInChildren<Text>().text = "Stop Recording";
            //resultText.text = "Say something :-)";        
        }
        

    }
}
