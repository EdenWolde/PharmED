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

    public void Populate(DrugDetail DrgDtl)
    {


        txtGname.text = txtGname.text + DrgDtl.genericName;
        txtbname.text = txtbname.text + DrgDtl.brandName;
        txtCategory.text = txtCategory.text + DrgDtl.pillCategory;
        txtIndication.text = txtIndication.text + DrgDtl.pillIndication;
        txtsideEffects.text = txtsideEffects.text + DrgDtl.pillSideEffects;
        txtothernotes.text = txtothernotes.text + DrgDtl.pillOtherNotes;


        SpeakDetail();

    }

    public void SpeakDetail()
    {
        if (SceneManager.GetActiveScene().name == "DrugDetail")
        {
            string cat = GameObject.Find("txtCategory").GetComponent<Text>().text;
            string BName = GameObject.Find("txtBrandName").GetComponent<Text>().text;
            string GName = GameObject.Find("txtGenericName").GetComponent<Text>().text;
            string Indic = GameObject.Find("txtIndication").GetComponent<Text>().text;
            string SE = GameObject.Find("txtSideEffects").GetComponent<Text>().text;
            string ON = GameObject.Find("txtOtherNotes").GetComponent<Text>().text;
            Interaction.msg = "                     " + cat + BName + GName + Indic + SE + ON;
        }
       
        Interaction.txtSpeech = GetComponent<TextToSpeech>();
        Interaction.txtSpeech.StartSpeaking(Interaction.msg);
      
    }
    private void Update()
    {
        transform.Rotate(0,0.5f,0);
    }
}
