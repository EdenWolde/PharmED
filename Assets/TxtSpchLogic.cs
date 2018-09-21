using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class TxtSpchLogic : MonoBehaviour, IInputClickHandler {

    private TextToSpeech txtSpeech;
    public string SpeakText;
    // Use this for initialization
    private void Awake () {
        txtSpeech = GetComponent<TextToSpeech>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var msg = string.Format(SpeakText, txtSpeech.Voice.ToString());
        txtSpeech.StartSpeaking(msg);
    }
}
