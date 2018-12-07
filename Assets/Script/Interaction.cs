using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;


public class Interaction : MonoBehaviour {

    public static GameObject ObjectInFocus;
    public static TextToSpeech txtSpeech;
    public string SpeakText;
    public static string msg;
    
    Text stxt;
    // Use this for initialization
    void Start()
    {
        //Initializing gesture to be used as an input method from the user

        GestureRecognizer gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
        gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
        gestureRecognizer.StartCapturingGestures();


        txtSpeech = GetComponent<TextToSpeech>();
        msg = string.Format(SpeakText, txtSpeech.Voice.ToString());
        txtSpeech.StartSpeaking(msg);



    }

    private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Debug.Log("You have tapped Something");
    }


    // Update is called once per frame

    void Update()
    {

        

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);                                // A ray being defined with start position and direction
        RaycastHit RayCastInfo;                                                                                          // a variable to store what the ray hit
        Physics.Raycast(ray, out RayCastInfo);

        if (Physics.Raycast(ray, out RayCastInfo))                                                                    // Storing the game object that is being hit
        { 
            ObjectInFocus = RayCastInfo.transform.gameObject;
           // DisplayHint();
            

        }
        else
            return;
    }

    /*

    public void DisplayHint()
    {
        var txtHint = GameObject.;
        txtHint.text = ObjectInFocus.GetComponent<DrugInfoClass>().brandName;
        txtHint.transform.position = new Vector3(ObjectInFocus.transform.position.x, ObjectInFocus.transform.position.y + 10, ObjectInFocus.transform.position.z);
        
    }
    */
}

  