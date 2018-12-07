using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Question
{
    public string strQuestion, strA, strB, strCorrectAnswer;
    public void setQuestion(string Question,string A,string B,string Answer)
    {
        this.strQuestion      = Question;
        this.strA             = A;
        this.strB             = B;
        this.strCorrectAnswer = Answer;
    }
    public static string CorrectAnswer;
    public static void AskQuestions(Question Q)
    {
        Game.EnableMultipleChoices();
        Text Questionlbl, txtA,txtb, txtc;                     //text variables to reference to the display
       
        //initializing the variables

        Questionlbl = GameObject.Find("txtQuest").GetComponent<Text>();
        txtA        = GameObject.Find("txtA").GetComponent<Text>();
        txtb        = GameObject.Find("txtB").GetComponent<Text>();
        txtc        = GameObject.Find("txtC").GetComponent<Text>();

        //Randomizing the multiple choices
        CorrectAnswer = Q.strCorrectAnswer;
        List<string> Choices = new List<string> { Q.strA, Q.strB, Q.strCorrectAnswer };
        Choices = RandomizeChoices(Choices);
        Q.strA = Choices[0];
        Q.strB = Choices[1];
        Q.strCorrectAnswer = Choices[2];

        //Assigning the values
        Questionlbl.text =  Q.strQuestion;
        txtA.text        = "A) " + Q.strA;
        txtb.text        = "B) " + Q.strB;
        txtc.text        = "C) " + Q.strCorrectAnswer;

        //setting the attribute that we will use to check if the user has answered correctly or not


        GameObject.Find("txtA").GetComponent<TextBoxBehaviour>().textInfo = Q.strA;
        GameObject.Find("txtB").GetComponent<TextBoxBehaviour>().textInfo = Q.strB;
        GameObject.Find("txtC").GetComponent<TextBoxBehaviour>().textInfo = Q.strCorrectAnswer;

        
    }
    public static List<string> RandomizeChoices(List<string> choices)
    {
        for(int i = 0; i<choices.Count;i++)
        {
            string temp          = choices[i];
            int randomIndex      = Random.Range(0, choices.Count);
            choices[i]           = choices[randomIndex];
            choices[randomIndex] = temp;
        }
        return choices;
    }

    //Checking if the selected answer is correct
    public static void CheckAnswer(string AnswerSelecion)
    {
        if (AnswerSelecion == "MCA(Clone)")
        {
            if (GameObject.Find("txtA").GetComponent<TextBoxBehaviour>().textInfo.Equals(CorrectAnswer))                     //if Option A is correct
            {
                //Speech saying correct
                nextQuestion();
            }
            else
            {
                return;             //Add speech for wrongly answered questions
               // GameObject.Find("MCA(Clone)").GetComponent<Rigidbody>().useGravity = true;
            }
        }
        else if (AnswerSelecion == "MCB(Clone)")
        {
            if (GameObject.Find("txtB").GetComponent<TextBoxBehaviour>().textInfo.Equals(CorrectAnswer/*Game.Quest[0].lstqstQuestions[0].strCorrectAnswer*/))                 //if Option B is correct
            {
                nextQuestion();
            }
            else
            {
                return;             //Add speech for wrongly answered questions
                //GameObject.Find("MCA(Clone)").GetComponent<Rigidbody>().useGravity = true;
            }
        }
        else if (AnswerSelecion == "MCC(Clone)")
        {
            if (GameObject.Find("txtC").GetComponent<TextBoxBehaviour>().textInfo.Equals(CorrectAnswer))             //if Option C is correct
            {
                nextQuestion();
            }
            else
            {
                return;             //Add speech for wrongly answered questions
                //GameObject.Find("MCA(Clone)").GetComponent<Rigidbody>().useGravity = true;
            }
        }

        else
            return;                                                                 //if the user clicks on something else the game returns nothing
    }

    public static void nextQuestion()
    {
        if (Game.Quest.Count >=1)
        {
            if (Game.Quest[0].lstqstQuestions.Count != 1)
            {
                Game.Quest[0].lstqstQuestions.Remove(Game.Quest[0].lstqstQuestions[0]);
                AskQuestions(Game.Quest[0].lstqstQuestions[0]);
            }
            else if (Game.Quest[0].lstqstQuestions.Count == 1)
            {
                DestroyPrefabChoices();
                Game.Quest.Remove(Game.Quest[0]);
                Game.ShowAllDrugs();
                if (Game.Quest.Count != 0)
                {
                    Game.SetQuest();
                }
                else
                {
                    Game.UpdateGameStatus();
                    //Go to scene selection. 
                }
            }
        }
    }

    //This function is used to destory the multiplchoice tags

    public static void DestroyPrefabChoices()
    {
        foreach (GameObject preFab in GameObject.FindGameObjectsWithTag("MultipleChoice"))
            GameObject.Destroy(preFab);
    }


}
