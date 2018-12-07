/****Eden Woldeselassie
     8/24/2018
     C# Script 
     GetDrugs Class
     Used for getting list of drugs 
     must be dynamic later on**********************************/

using System.Collections;



public class GetDrugs {

    public ArrayList DrugsLists;

    // Change this to come form an outside source
        public  ArrayList GetDrugListforGame()
        {

        //Array List of Top 200 FDA approved drugs with the information that the student needs to know. 
        DrugsLists = new ArrayList() {

                                        new DrugDetail("Mirtazapine(PO)", "Remeron", "Alpha2 antagonist", "MDD","Drowsiness, weight gain, xerostomia, increased appetite, constipation",""),

                                        new DrugDetail("Bupropion(PO)", "Wellbutrin SR, WellbutrinXL", "Norepinephrine-dopamine reuptake inhibitor", "MDD",
                                                       "Tachycardia, headache,agitation,dizziness, insomnia, weight loss","use may increase risk of seizures"),

                                        new DrugDetail("Atomoxetine(PO)", "Strattera","Serotonin-norepinephrine reuptake inhibitor", "ADHD", 
                                                        "Headache, xerostomia, nausea, vomiting, constipation, decreased appetite, insomnia",
                                                        "CI within 14 days of MAOI; do not D/C abruptly"),

                                        new DrugDetail("Desvenlafaxine", "Pristiq","Selective serotonin reuptake inhibitor (SSRI)", "MDD",
                                                        "Headache, xerostomia, nausea, vomiting, constipation, decreased appetite, insomnia",
                                                        "CI within 14 days of MAOI; do not D/C abruptly"),

                                        new DrugDetail("Duloxetine", "Cymbalta","Selective serotonin reuptake inhibitor (SSRI)", "MDD",
                                                       "Headache, xerostomia, nausea, vomiting, constipation, decreased appetite, insomnia",
                                                       "CI within 14 days of MAOI; do not D/C abruptly")
                                        };

        return DrugsLists;
         }
}
