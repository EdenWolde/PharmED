/****Eden Woldeselassie
     8/24/2018
     C# Script 
     DrugDetail Class
     A constructor class for the drug objects *******************/
using UnityEngine.UI;


public class DrugDetail /*: MonoBehaviour*/ {



    public string genericName, brandName, pillCategory, pillIndication, pillSideEffects, pillOtherNotes;       //String Variable that define a drug


  // Constructor method

    public DrugDetail(string gName, string bName, string pCategory, string pIndication, string pSideEffects, string pOtherNotes)
    {
        genericName        = gName;
        brandName          = bName;
        pillCategory       = pCategory;
        pillIndication     = pIndication;
        pillSideEffects    = pSideEffects;
        pillOtherNotes     = pOtherNotes;
    }



}
