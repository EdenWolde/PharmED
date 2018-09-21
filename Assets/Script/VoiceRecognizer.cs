using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognizer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Activating the speech recognizer for user command (input)

        KeywordRecognizer KWR = new KeywordRecognizer(new[] {"Stop"});  
        KWR.OnPhraseRecognized += KWR_OnPhraseRecognized;
        KWR.Start();
	}

    private void KWR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
