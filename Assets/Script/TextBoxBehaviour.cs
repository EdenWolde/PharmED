using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine.XR.WSA.Input;
 
public class TextBoxBehaviour : MonoBehaviour {
    public string textInfo;

    // Use this for initialization

    private void Start()
    {
        // Initializing keyword recognizer to listen to the user when they speak the answer
        //GestureRecognizer gReconizer = new GestureRecognizer();
        //gReconizer.SetRecognizableGestures(GestureSettings.Tap);
        //gReconizer.TappedEvent += GReconizer_TappedEvent;
        //gReconizer.StartCapturingGestures();

        List<string> KeywordDictionary = new List<string>();
        KeywordDictionary.Add("A");
        KeywordDictionary.Add("B");
        KeywordDictionary.Add("C");
        KeywordRecognizer KWR = new KeywordRecognizer(KeywordDictionary.ToArray());
        KWR.OnPhraseRecognized += KWR_OnPhraseRecognized;
        KWR.Start();
    }

    //private void GReconizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    //{
    //    Debug.Log("Answered*******************");
    //}

    private void KWR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
     
        Debug.Log("Answered*******************"+args);
        this.GetComponent<Renderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        DisplayMessage();
    }

    public void checkAnswer()
    {
        if (this.textInfo == Game.Quest[0].lstqstQuestions[0].strCorrectAnswer)
        {
            Debug.Log("Correct");
            //remove the question
            //go to next scene
        }
        else
            this.GetComponent<Renderer>().enabled = false; 
        
    }

    public void DisplayMessage()
    {
        Debug.Log("You have clicked the textbox.......................");
    }
}
