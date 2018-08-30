using UnityEngine;
using UnityEngine.UI;

public class DrugDetail : MonoBehaviour {


    public Text txtGname, txtbname, txtCategory, txtIndication, txtsideEffects, txtothernotes;
    private string genericName, brandName, pillCategory, pillIndication, pillSideEffects, pillOtherNotes;
   

    public void SetDetails(string gName, string bName, string pCategory, string pIndication, 
                           string pSideEffects, string pOtherNotes)
    {
        genericName        = gName;
        brandName          = bName;
        pillCategory       = pCategory;
        pillIndication     = pIndication;
        pillSideEffects    = pSideEffects;
        pillOtherNotes     = pOtherNotes;
    }



    public  void Populate()
    {
        SetDetails("Mirtazapine(PO)", "Remeron","Alpha2 antagonist", "MDD",
                   "Drowsiness, weight gain, xerostomia, increased appetite, constipation",
                               "");
        
        txtGname.text         =  txtGname.text       +  genericName;
        txtbname.text         =  txtbname.text       +  brandName;
        txtCategory.text      =  txtCategory.text    +  pillCategory;
        txtIndication.text    =  txtIndication.text  +  pillIndication;
        txtsideEffects.text   =  txtsideEffects.text +  pillSideEffects;
        txtothernotes.text    = txtothernotes.text   +  pillOtherNotes;


     
        
    }
}
