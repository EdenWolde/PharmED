using UnityEngine.UI;


public class DrugDetail /*: MonoBehaviour*/ {



    public string genericName, brandName, pillCategory, pillIndication, pillSideEffects, pillOtherNotes;       //String Variable that define a drug


  

    public DrugDetail(string gName, string bName, string pCategory, string pIndication, string pSideEffects, string pOtherNotes)
    {
        genericName        = gName;
        brandName          = bName;
        pillCategory       = pCategory;
        pillIndication     = pIndication;
        pillSideEffects    = pSideEffects;
        pillOtherNotes     = pOtherNotes;
    }


    // Populate writes the drug information on the UI screen

}
