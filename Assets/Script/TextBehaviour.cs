using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
public class TextBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //LoadGame.PalyGame.DisableMultipleChoices();
        string[] AnswerKeyWords = new string[] { 
                                                 GameObject.Find("txtA").GetComponent<Text>().text,
                                                 GameObject.Find("txtB").GetComponent<Text>().text,
                                                 GameObject.Find("txtC").GetComponent<Text>().text };
   
        KeywordRecognizer KWR = new KeywordRecognizer(AnswerKeyWords);
        KWR.OnPhraseRecognized += KWR_OnPhraseRecognized;
        KWR.Start();
		
	}

    private void KWR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args);
       
        if (LoadGame.AnswerQuestion == this.GetComponent<Text>().text)
        {
            LoadGame.Question_Answered = true;
        } 
    }

    // Update is called once per frame
    void Update () {
		
	}

     void OnMouseDown()
    {
        Debug.Log("You have clicked a text");
        if (LoadGame.AnswerQuestion == this.GetComponent<Text>().text)
        {
            LoadGame.Question_Answered = true;
            Debug.Log("Correct Answer" + LoadGame.AnswerQuestion);
        }
            
    }
}
