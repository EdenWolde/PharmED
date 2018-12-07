/*************************          PharmEd 
 *                              Comprhensive Project
 *                                  9/04/2018
 *                                  Description
 *               This class is called DrugInfo which inherits from a base class named Monobehaviour. This class is atached to each drug in the asset component. 
 *               One purposes of this class is to set attributes (Information of the drugs). Second, it is used to capture user tap as to select the drug during quest. Last,
 *               It is used to verify if the user has tapped on the correct drug.
 *             
 *************************/
using UnityEngine;
using UnityEngine.XR.WSA.Input;
public class DrugInfo : MonoBehaviour
{
    public string genericName, brandName, pillCategory, pillIndication, pillSideEffects, pillOtherNotes;        // Variables used as attriutes of the drugs
    public Transform MCA, MCB, MCC;
    // Use this for initialization
    void Start ()
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
    public virtual void OnInputclicked()
    {
    }
    // Update is called once per frame
    void Update ()
    {
    }
    private void OnMouseDown()
    {

        CheckDrug();
    }
    public void CheckDrug()
    {
        if (this.gameObject.GetComponent<DrugInfo>().brandName == Game.Quest[0].strQuest)                 //When the drug is identified correctly
        {

            Game.HideAllDrugs();                                      //hide all drugs from the scene 
            this.gameObject.SetActive(true);                                //show the current drug

            Question.AskQuestions(Game.Quest[0].lstqstQuestions[0]);                                //Asking the question on top
            instantiatePrefab();
        }
        else if (this.gameObject.GetComponent<DrugInfo>().genericName != Game.Quest[0].strQuest)
        {
            this.gameObject.SetActive(false);
        }
        else
            return;

    }//end CheckDrug
    public void instantiatePrefab()
    {
        Instantiate(MCA, new Vector3(-17f,    -3f, 17.856f),  MCA.rotation);
        Instantiate(MCB, new Vector3(-13f, -3f, 17.856f), MCB.rotation);
        Instantiate(MCC, new Vector3(-9f,  -3f, 17.856f),  MCC.rotation);
    }
}//end DrugInfo


