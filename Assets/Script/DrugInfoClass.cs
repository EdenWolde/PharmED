using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class DrugInfoClass : MonoBehaviour {
    public string genericName, brandName, pillCategory, pillIndication, pillSideEffects, pillOtherNotes;
    GameObject ObjectInFocus;
    public Text quest, A, B, C;

    void Start()
    {
        GestureRecognizer gReconizer = new GestureRecognizer();
        gReconizer.SetRecognizableGestures(GestureSettings.Tap);
        gReconizer.TappedEvent += GReconizer_TappedEvent;
        gReconizer.StartCapturingGestures();
    }

    private void GReconizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
       
        CheckDrug();
    }


    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);                                // A ray being defined with start position and direction
        RaycastHit RayCastInfo;                                                                                          // a variable to store what the ray hit
        Physics.Raycast(ray, out RayCastInfo);

        if (Physics.Raycast(ray, out RayCastInfo))                                                                   //if the ray has hit something
        {
            // Storing the game object that is being hit
            ObjectInFocus = RayCastInfo.transform.gameObject;

        }
        else
            return;
    }


    private void OnMouseDown()
    {
        CheckDrug();
    }

    public void CheckDrug()
    {
        if (this.gameObject.GetComponent<DrugInfoClass>().genericName == LoadGame.DrugOnQuest && ObjectInFocus.tag == "Drug")                    //When the drug is identified
        {
            LoadGame.DrugFound = true;
            foreach (GameObject Drg in GameObject.FindGameObjectsWithTag("Drug"))
                Drg.GetComponent<Renderer>().enabled = false;                                                                        //Remove all drugs
            this.gameObject.GetComponent<Renderer>().enabled = true;
            GenerateQuestions(this.gameObject);                                                     //generate questioins

        }
        else if (ObjectInFocus.tag == "Drug")
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;        //Drop the wrongly identified drug
        else
            return;
    }



    private void GenerateQuestions(GameObject DrugInLearning)
    {
       
       string[,] choices = new string[,] { 
                                           {DrugInLearning.GetComponent<DrugInfoClass>().brandName,"brand name" },
                                           {DrugInLearning.GetComponent<DrugInfoClass>().pillCategory, "category"},
                                           {DrugInLearning.GetComponent<DrugInfoClass>().pillIndication,"Indication"},
                                           {DrugInLearning.GetComponent<DrugInfoClass>().pillSideEffects, "Side Effect"},
                                           {DrugInLearning.GetComponent<DrugInfoClass>().pillOtherNotes, "Extra information" }
                            };

        string[] Ch = new string[3];
        System.Random RandomNumber = new System.Random();
        string question = "What is the brandname of " + (DrugInLearning.GetComponent<DrugInfoClass>().genericName);
        for (int j = 0; j < 2; j++)
        {
            
            Ch[j] = choices[RandomNumber.Next(0, 5), 0];
        }

        Ch[2] = DrugInLearning.GetComponent<DrugInfoClass>().brandName;
        Question Question1 = new Question(question, Ch[0], Ch[1], Ch[2]);
        SetQuestionFields(Question1);


    }

    public  void SetQuestionFields(Question Q)
    {

        quest = GameObject.Find("txtQuest").GetComponent<Text>();
        A     = GameObject.Find("txtA").GetComponent<Text>();
        B     = GameObject.Find("txtB").GetComponent<Text>();
        C     = GameObject.Find("txtC").GetComponent<Text>();

        quest.text = Q.QuestionHead;
        A.text     = "A) " + Q.ChoiceA;
        B.text     = "B) " + Q.ChoiceB;
        C.text     = "C) " + Q.Answer;
        LoadGame.AnswerQuestion = Q.Answer;

        LoadGame.PlayGame.EnableMultipleChoices();


    }
}
