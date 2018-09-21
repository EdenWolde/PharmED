using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class LoadGame : MonoBehaviour
{
    public static bool DrugFound = false, Question_Answered = false;                    //Status checks
    public static string DrugOnQuest;                                                   //Drug to be found
    public static string AnswerQuestion;




    void Start()
    {

        PlayGame Game = new PlayGame();
        Game.Start();

    }

    public class PlayGame : GetDrugs
    {
        public static new ArrayList DrugsLists = new ArrayList();                       //Lists of drugs and thier definition
        public int LEVEL, DrugNumber = 0;
        public static List<GameObject> Drugs = new List<GameObject>();                  //Lists of gameobject in the scene
        public Text title, score, lvl, quest;
        public FileStream Fstream = new FileStream("C:\\Users\\edenb\\Documents\\PharmED\\GameStatus.txt", FileMode.OpenOrCreate);


        // Use this for initialization

        public void Start()
        {

            AssignDrugDetail();
            AssignLevelScore();
            StartQuest();

        }

        // Update is called once per frame
        public void AssignDrugDetail()
        {

            int i = 0;
            DrugsLists = GetDrugListforGame();
            foreach (GameObject Dgs in GameObject.FindGameObjectsWithTag("Drug"))
                Drugs.Add(Dgs);                                                                                 //Modify with spatial mapping later on 
            foreach (GameObject Dgs in Drugs)
            {

                DrugDetail Drug = (DrugDetail)DrugsLists[i];

                Dgs.GetComponent<DrugInfoClass>().genericName = Drug.genericName;
                Dgs.GetComponent<DrugInfoClass>().brandName = Drug.brandName;
                Dgs.GetComponent<DrugInfoClass>().pillCategory = Drug.pillCategory;
                Dgs.GetComponent<DrugInfoClass>().pillIndication = Drug.pillIndication;
                Dgs.GetComponent<DrugInfoClass>().pillOtherNotes = Drug.pillIndication;
                Dgs.GetComponent<DrugInfoClass>().pillSideEffects = Drug.pillSideEffects;
                Dgs.GetComponent<Renderer>().material.color = new Color(1f, 1f * i, (255 - (i * 50)) / 255f);
                i++;

            }

        }//AssignDrugDetail
        public void AssignLevelScore()
        {
            //reading the player status from a file and assigning 

            StreamReader sr = new StreamReader(Fstream);

            LEVEL = int.Parse(sr.ReadLine());
            lvl = GameObject.Find("txtLvl").GetComponent<Text>();
            score = GameObject.Find("txtScore").GetComponent<Text>();
            title = GameObject.Find("txtTitle").GetComponent<Text>();
            lvl.text = ("Level: " + LEVEL.ToString());
            score.text = ("Score: " + (sr.ReadLine())).ToString();
            title.text = "Title: " + sr.ReadLine();
            DrugNumber = int.Parse(sr.ReadLine());
            sr.Dispose();
        } // AssignLevelScore
        public void StartQuest()
        {

            quest = GameObject.Find("txtQuest").GetComponent<Text>();
            DrugOnQuest = ((DrugDetail)DrugsLists[0]).genericName;
            quest.text = ("Find " + ((DrugDetail)DrugsLists[0]).genericName).ToString();
            DisableMultipleChoices();
        }
        public static void DisableMultipleChoices()
        {
            GameObject.Find("txtA").GetComponent<Text>().enabled = false;
            GameObject.Find("txtB").GetComponent<Text>().enabled = false;
            GameObject.Find("txtC").GetComponent<Text>().enabled = false;
        }
        public static void EnableMultipleChoices()
        {
            GameObject.Find("txtA").GetComponent<Text>().enabled = true;
            GameObject.Find("txtB").GetComponent<Text>().enabled = true;
            GameObject.Find("txtC").GetComponent<Text>().enabled = true;
        }
    }//Play game
}//LG
