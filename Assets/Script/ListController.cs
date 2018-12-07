using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;

public class ListController : MonoBehaviour {
    public  ArrayList DrugsLists;
    public GameObject ListItemPrefab, pnl;
    public string[] Keywords = new string[] { "Brimonidine", "Dorzolamide", "Cyclosporine", "Timolol", "Permethrin", "Dutasteride" ,
                                               "Finasteride","Doxazosin","Terazosin","Tamsulosin","Benazepril","Enalapril","Lisinopril",
                                               "Quinapril","Ramipril","Beclomethason","Budesonide","Fluticasone propionate","Fluticason and Salmeterol",
                                               "Budesonide and moontelukast","Penicillin five potassium", "Amoxicillin", "Ampicillin" };
    public ConfidenceLevel Conf = ConfidenceLevel.Medium;
    public float speed = 1;

    private void Start()
    {

        KeywordRecognizer KWR = new KeywordRecognizer(Keywords, Conf);
        KWR.OnPhraseRecognized += KWR_OnPhraseRecognized;
        KWR.Start();

        /*****************************************************Data to be displayed
                                                              Must be changed later on when database or file input sorce has been configured *****************************************/
        DrugsLists = new ArrayList() {

             #region DrugLists

                                        new DrugList("Heads, Ears, Eyes, Nose, Throat", "Brimonidine"),
                                        new DrugList("Heads, Ears, Eyes, Nose, Throat", "Dorzolamide"),
                                        new DrugList("Heads, Ears, Eyes, Nose, Throat", "Cyclosporine"),
                                        new DrugList("Heads, Ears, Eyes, Nose, Throat", "Timolol"),
                                        new DrugList("Heads, Ears, Eyes, Nose, Throat", "Permethrin"),
                                        new DrugList("Renal", "Dutasteride"),
                                        new DrugList("Renal", "Finasteride"),
                                        new DrugList("Renal", "Doxazosin"),
                                        new DrugList("Renal", "Terazosin"),
                                        new DrugList("Renal", "Tamsulosin"),
                                        new DrugList("Cardiovascular", "Benazepril"),
                                        new DrugList("Cardiovascular", "Enalapril"),
                                        new DrugList("Cardiovascular", "Lisinopril"),
                                        new DrugList("Cardiovascular", "Quinapril"),
                                        new DrugList("Cardiovascular", "Ramipril"),
                                        new DrugList("Pulmonary", "Beclomethason"),
                                        new DrugList("Pulmonary", "Budesonide"),
                                        new DrugList("Pulmonary", "Fluticasone propionate"),
                                        new DrugList("Pulmonary", "Fluticason and Salmeterol"),
                                        new DrugList("Pulmonary", "Budesonide and moontelukast"),
                                        new DrugList("Infectious Diseases", "Penicillin V potassium"),
                                        new DrugList("Infectious Diseases", "Amoxicillin"),
                                        new DrugList("Infectious Diseases", "Ampicillin"),
                                        new DrugList("Infectious Diseases", "Amoxicillin and clavulanate"),
                                        new DrugList("Infectious Diseases", "Ampicillin and Sulbactam"),
                                        new DrugList("Musculoskeletal", "Tizanidine"),
                                        new DrugList("Musculoskeletal", "Hydroxychloroquine"),
                                        new DrugList("Musculoskeletal", "Colchicine"),
                                        new DrugList("Musculoskeletal", "Diclofenac"),
                                        new DrugList("Musculoskeletal", "Ibuprofen"),
                                        new DrugList("Endocrine", "Metformin"),
                                        new DrugList("Endocrine", "Saxagliption"),
                                        new DrugList("Endocrine", "Sitagliptin"),
                                        new DrugList("Endocrine", "Liraglutide"),
                                        new DrugList("Endocrine", "Insulin Detemir"),
                                        new DrugList("Neurological and Psychiatric disease", "Mirtazapine"),
                                        new DrugList("Neurological and Psychiatric disease", "Bupropion"),
                                        new DrugList("Neurological and Psychiatric disease", "Atomoxetine"),
                                        new DrugList("Neurological and Psychiatric disease", "Desvenlafaxine"),
                                        new DrugList("Neurological adn Psychiatric disease", "Duloxetine"),
                                        new DrugList("Gastrology", "Mesalamine"),
                                        new DrugList("Gastrology", "Dicyclomine"),
                                        new DrugList("Gastrology", "Hyoscyamine"),
                                        new DrugList("Gastrology", "Lubiprostone"),
                                        new DrugList("Gastrology", "Dexamethasone"),
                                        new DrugList("Pain, Hematology and Oncology", "Fentanyl"),
                                        new DrugList("Pain, Hematology and Oncology", "Hydromorphone"),
                                        new DrugList("Pain, Hematology and Oncology", "Morphine"),
                                        new DrugList("Pain, Hematology and Oncology", "Oxycodone"),
                                        new DrugList("Pain, Hematology and Oncology", "Methadone"),
                                        new DrugList("Pain, Hematology and Oncology", "Fentanyl")
        #endregion
                                      };



        
        string cat = null;
        int intYPosInc = 0;                                             //A variable to increment the Y position of each prefab

        //Iterating through the data to instantiate the prefab

        
        foreach (DrugList DL in DrugsLists)
        {
            GameObject newDrug = Instantiate(ListItemPrefab) as GameObject;
            ListItemController controller = newDrug.GetComponent<ListItemController>();                                 

            if (cat != DL.Category)
                controller.Category.text = DL.Category;
            else
                controller.Category.enabled = false;
            controller.GenericName.text = DL.GenericName;
            cat = DL.Category;

          
            newDrug.transform.SetParent(pnl.transform);                         //Set the prefabs to the view content
            //newDrug.transform.localScale = Vector3.one;
            newDrug.transform.position = new Vector3(pnl.transform.position.x, pnl.transform.position.y - intYPosInc , pnl.transform.position.z);
            intYPosInc += 50;

        } //endforeach

    }

    private void KWR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Interaction.txtSpeech.StartSpeaking(args.ToString());
    }
}
