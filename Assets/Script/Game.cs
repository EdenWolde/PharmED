/*************************          PharmEd 
 *                              Comprhensive Project
 *                                  9/04/2018
 *                                  Description
 *               This class is called Game.  Game is treated as an object in the design phase. It has level, score, title and list of quests as a global variable.
 *               This class does couples of things. 
 *               First, it sets the gamestatus by retriving the previously saved status like: player level, score and title. Second, it is used to get list of quests. 
 *                                  Modification
 *               Need to make the input of drug lists dynamic by integrating database or a txt.file
 *               
 *************************/



using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class Game : GameStatus{

    public static int intLevel, intScore;
    public static string strTitle;
    public  static List<Quest> Quest = new List<Quest>();
    public  static Transform [] DrugsInLevel;
    //public static GameStatus GS = new GameStatus();

    //this method is called from the game class 
    public void SetGame()
        {
            GetGameStatus();
            SetGameStatus();
            AssignDrugs();
            GetListOfQuest();
            SetQuest();
            
        }//end SetGame
// this method is used to retrieve the status from a text file that resides under the assets folder
    public void GetGameStatus()
    {
        /*******************To read from text file with in the asset************************/
        TextAsset Asset = (TextAsset)Resources.Load("GameStatus");
        string textcontent = Asset.text;
        //List <string> gamestatus = new List<string>();
        string[] status = textcontent.Split("\n".ToCharArray());
        intLevel = int.Parse(status[0]);
        intScore = int.Parse(status[1]);
        strTitle = status[2].ToString();
    }//end GetGameStatus 
//This method is used to initialize the status (score, title, level) display 
    public void SetGameStatus()
    {
        Text lvl, score, title;                     //text variables to reference to the display

        //initializing the variables

        lvl   = GameObject.Find("txtLvl").GetComponent<Text>();
        score = GameObject.Find("txtScore").GetComponent<Text>();
        title = GameObject.Find("txtTitle").GetComponent<Text>();

        //Assigning the values

        lvl.text = ("Level: " + intLevel.ToString());
        score.text = ("Score: " + intScore.ToString());
        title.text = ("Title: " + strTitle.ToString());
    }//end SetGameStatus
    public void AssignDrugs()
    {
        //int i = 0;
        List<GameObject> Drugs = new List<GameObject>();                                                //a list to store gameobjects in the scene                                                                                     // Counter to variate color of the objects. Will be removed once the drugs come in
        ArrayList DrugsLists = GetDrugListforGame();
        foreach (GameObject Dgs in GameObject.FindGameObjectsWithTag("Drug"))                       //initializing the list with game objects
            Drugs.Add(Dgs);
       //Modify with spatial mapping later on 
        foreach (GameObject Dgs in Drugs)
        {
            for(int i = 0; i<DrugsLists.Count;i++)
            {
                DrugDetail Drug = (DrugDetail)DrugsLists[i];
                if((Drug.genericName + ("(Clone)")).Equals(Dgs.name))
                {
                    Dgs.GetComponent<DrugInfo>().genericName        = Drug.genericName;
                    Dgs.GetComponent<DrugInfo>().brandName          = Drug.brandName;
                    Dgs.GetComponent<DrugInfo>().pillCategory       = Drug.pillCategory;
                    Dgs.GetComponent<DrugInfo>().pillIndication     = Drug.pillIndication;
                    Dgs.GetComponent<DrugInfo>().pillOtherNotes     = Drug.pillIndication;
                    Dgs.GetComponent<DrugInfo>().pillSideEffects    = Drug.pillSideEffects;
                }
            }
        }
    }//end AssignDrugs
    public ArrayList GetDrugListforGame()
    {
        ArrayList DrugsLists;
        //Array List of Top 200 FDA approved drugs with the information that the student needs to know. 
        DrugsLists = LoadDrugs(intLevel);
        instanciateLevel(intLevel);
        return DrugsLists;

    }// GetDrugListforGame
    public ArrayList LoadDrugs(int LevelOfGame)
    {
        ArrayList druginfo = new ArrayList();
        TextAsset Asset = (TextAsset)Resources.Load("DrugInformation/" + LevelOfGame.ToString());
        string textcontent = Asset.text;
        string[] DrugInfo = textcontent.Split("\n".ToCharArray());
        for (int i = 0; i < DrugInfo.Length - 1; i++)
        {
            string[] IndividualDetail = DrugInfo[i].Split(";".ToCharArray());
            druginfo.Add(new DrugDetail( 
                IndividualDetail.Length >= 1 ? IndividualDetail[0] : null ,
                IndividualDetail.Length >= 2 ? IndividualDetail[1] : null,
                IndividualDetail.Length >= 3 ? IndividualDetail[2] : null,
                IndividualDetail.Length >= 4 ? IndividualDetail[3] : null,
                IndividualDetail.Length >= 5 ? IndividualDetail[4] : null,
                IndividualDetail.Length >= 6 ? IndividualDetail[5] : null ));
        }
        return druginfo;
    }
    //This method is used to initiate multiple quests with in a game. 
    public void GetListOfQuest()
    {
        
        foreach (GameObject Dgs in GameObject.FindGameObjectsWithTag("Drug"))
        {

            Quest Q1 = new Quest();                 //Geting list of quests based on the drugs on the scene
            Q1.SetQuest(Dgs);
            Quest.Add(Q1);
          }
      
    }//end GetListOfQuest
    //public void GetObjects(){}
    public static void SetQuest()
    {
        DisableMultipleChoices();
        Text txtQuest =  GameObject.Find("txtQuest").GetComponent<Text>();
        txtQuest.text = "Find: " + Quest[0].strQuest;
    }//end setQuest
    //This function is used to turn off the visibilities of the myltiple choice. The code finds the texts by name and enables them. 
    public static void DisableMultipleChoices()
    {
        GameObject.Find("txtA").GetComponent<Text>().enabled = false;
        GameObject.Find("txtB").GetComponent<Text>().enabled = false;
        GameObject.Find("txtC").GetComponent<Text>().enabled = false;
    }//DisableMultipleChoices
    //This function is used to turn on the visibilities of the myltiple choice. The code finds the text boxes by name and disables them. 
    public static void EnableMultipleChoices()
    {
        GameObject.Find("txtA").GetComponent<Text>().enabled = true;
        GameObject.Find("txtB").GetComponent<Text>().enabled = true;
        GameObject.Find("txtC").GetComponent<Text>().enabled = true;
    }//EnableMultipleChoices
    //This method is used to remove aquest once the player has completed the quest. 
    public void removeQuest()
    {
        Quest.RemoveAt(0);
    }
    public static void HideAllDrugs ()
    {
        GameObject Parent = GameObject.Find("ParentDrugs");
        Debug.Log(Parent.transform.childCount);
    }
    public static void ShowAllDrugs()
    {
        foreach (GameObject Drg in GameObject.FindGameObjectsWithTag("Drug"))
            Drg.gameObject.SetActive(true);
    }
    public static void UpdateGameStatus()
    {
        intLevel++;                                                //increment level
        intScore += 5;

        if (intLevel >= 1 && intLevel <= 3)
        {
            strTitle = "Trainee";
        }
        else if (intLevel >= 4 && intLevel <= 6)
        {
            strTitle = "Pharm Tech";
        }
        else if (intLevel >= 7 && intLevel <= 9)
        {
            strTitle = "Pharm Intern";
        }
        else if (intLevel == 10)
        {
            strTitle = "Pharmacist";
        }
        else
        {
            return;
        }
        WriteToFile();  
    }
    public static void WriteToFile()
    {
        TextAsset Asset = (TextAsset)Resources.Load("GameStatus");
        string [] status = { intLevel.ToString() ,intScore.ToString(), strTitle };
        File.WriteAllLines(AssetDatabase.GetAssetPath(Asset), status);
        EditorUtility.SetDirty(Asset);
    }
    public void instanciateLevel(int level)
    {
        int i = 0;
        DrugsInLevel = Resources.LoadAll<Transform>(level.ToString() + "/");
        foreach (Transform Drug in DrugsInLevel)
        {
            //GameObject.Find("ParentDrugs").transform.parent =
            Instantiate(Drug, new Vector3(-2.18f + i, 0f , 9.47f), Drug.rotation);
            i=+20;
        }    
    }
}
