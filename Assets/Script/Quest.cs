/*************************          PharmEd 
 *                              Comprhensive Project
 *                                  9/04/2018
 *                                  Description
 *               This class is called LoadGame which inherits from a base class named Monobehaviour. This class is atached to the camera. 
 *               There are some purposes to this class. First, it is used to initialize the game scene. This is done under the start method.
 *               Second, it is used to collect objects that the player is gazing at. This can be found in the update method. Third, the drugs or
 *               pills on the scene are initialized with attributes (information that the player needs to know about). 
 *                                  Modification
 *               Need to make the input of drug lists dynamic by integrating database or a txt.file
 *                                  Paradiagm shift.
 *               Don't need to read from external file. The drugs in the resources can be stored with the information. 
 *               
 *************************/

using System.Collections.Generic;
using UnityEngine;
public class Quest
{
    public string strQuest;
    public List<Question> lstqstQuestions;

    

    public void SetQuest(GameObject Drug)
    {
        this.strQuest = Drug.GetComponent<DrugInfo>().brandName;
        this.lstqstQuestions = GetListOfQuestions(Drug);
      
    }

    public List<Question> GetListOfQuestions(GameObject Drug)
    {
        List<Question> ListOfQuestions = new List<Question>();
        ListOfQuestions.Add(GetQuestion(Drug.GetComponent<DrugInfo>().genericName.ToString(),    "generic name ", Drug.GetComponent<DrugInfo>().brandName.ToString()));
        ListOfQuestions.Add(GetQuestion(Drug.GetComponent<DrugInfo>().pillCategory.ToString(),   "category ",     Drug.GetComponent<DrugInfo>().brandName.ToString()));
        ListOfQuestions.Add(GetQuestion(Drug.GetComponent<DrugInfo>().pillIndication.ToString(), "Indication ",   Drug.GetComponent<DrugInfo>().brandName.ToString()));
        ListOfQuestions.Add(GetQuestion(Drug.GetComponent<DrugInfo>().pillSideEffects.ToString(),"Other Notes ",  Drug.GetComponent<DrugInfo>().brandName.ToString()));
        ListOfQuestions.Add(GetQuestion(Drug.GetComponent<DrugInfo>().pillOtherNotes.ToString(), "other notes ",  Drug.GetComponent<DrugInfo>().brandName.ToString()));

        return ListOfQuestions;

    }

    public Question GetQuestion(string question, string detail, string brandname)
    {
        Question Q1 = new Question();
        string Question = "Choose " + detail + "for " + brandname;
        Q1.setQuestion(Question, "Distractor", "distractor", question);
        return Q1;
    }

  
       
}
