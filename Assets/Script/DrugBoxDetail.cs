/****Eden Woldeselassie
     8/24/2018
     C# Script 
     DrugboxDetail Class
     Used to generate and assign the details of the drug to the user *******************/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity;
public class DrugBoxDetail : MonoBehaviour {
    public Text txtGname, txtbname, txtCategory, txtIndication, txtsideEffects, txtothernotes;                  //Variables to hold the text components in the GameObject (GUI)
    public static DrugDetail Dr;
   

    // Use this for initialization
    void Start () {
        
    Dr = new DrugDetail("Mirtazapine(PO)", "Remeron", "Alpha2 antagonist", "MDD",
                        "Drowsiness, weight gain, xerostomia, increased appetite, constipation",
                        "");
        Populate(Dr);   
        
    }

    //Assigning the display components (Texts) with information the drug

    public void Populate(DrugDetail DrgDtl)
    {


        txtGname.text = txtGname.text + DrgDtl.genericName;
        txtbname.text = txtbname.text + DrgDtl.brandName;
        txtCategory.text = txtCategory.text + DrgDtl.pillCategory;
        txtIndication.text = txtIndication.text + DrgDtl.pillIndication;
        txtsideEffects.text = txtsideEffects.text + DrgDtl.pillSideEffects;
        txtothernotes.text = txtothernotes.text + DrgDtl.pillOtherNotes;


        SpeakDetail();                                                              //Calling the function to tell the details

    }


    // This function reads the details displayed to the user. 

    public void SpeakDetail()
    {
        string cat = null, BName = null, GName = null, Indic = null,  SE = null, ON = null;
        if (SceneManager.GetActiveScene().name == "DrugDetail")
        {
             cat = GameObject.Find("txtCategory").GetComponent<Text>().text;
             BName = GameObject.Find("txtBrandName").GetComponent<Text>().text;
             GName = GameObject.Find("txtGenericName").GetComponent<Text>().text;
             Indic = GameObject.Find("txtIndication").GetComponent<Text>().text;
             SE = GameObject.Find("txtSideEffects").GetComponent<Text>().text;
             ON = GameObject.Find("txtOtherNotes").GetComponent<Text>().text;
            //Interaction.msg = "                     " + cat + BName + GName + Indic + SE + ON;
        }
       
        Interaction.txtSpeech = GetComponent<TextToSpeech>();
        Interaction.txtSpeech.StartSpeaking(cat);
        Interaction.txtSpeech.StartSpeaking(BName);
        Interaction.txtSpeech.StartSpeaking(GName);
        Interaction.txtSpeech.StartSpeaking(Indic);
        Interaction.txtSpeech.StartSpeaking(SE);
        Interaction.txtSpeech.StartSpeaking(ON);

    }

    // a function to rotate the drug that is being viewd by the player

    private void Update()
    {
        transform.Rotate(0,0.5f,0);
    }

}
