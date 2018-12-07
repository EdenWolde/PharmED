using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuest : MonoBehaviour {
    public int intLevel;
    public Transform[] DrugPrefabs;
    public ArrayList druginfo = new ArrayList();

    public void LoadDrugs()
    {
        TextAsset Asset = (TextAsset)Resources.Load("DrugInformation/" + intLevel.ToString());
        string textcontent = Asset.text;
        string[] DrugInfo = textcontent.Split("\n".ToCharArray());
        for (int i = 0; i < DrugInfo.Length - 1; i++)
        {
                string[] IndividualDetail = DrugInfo[i].Split(";".ToCharArray());
                druginfo.Add(new DrugDetail(
                IndividualDetail.Length >= 1 ? IndividualDetail[0] : null,
                IndividualDetail.Length >= 2 ? IndividualDetail[1] : null,
                IndividualDetail.Length >= 3 ? IndividualDetail[2] : null,
                IndividualDetail.Length >= 4 ? IndividualDetail[3] : null,
                IndividualDetail.Length >= 5 ? IndividualDetail[4] : null,
                IndividualDetail.Length >= 6 ? IndividualDetail[5] : null));
        } 
    }
    public void instanciateLevel(int level)
    {
        int i = 0;
        DrugPrefabs = Resources.LoadAll<Transform>(level.ToString() + "/");

        foreach (Transform Drug in DrugPrefabs)
        {
            GameObject.Find("ParentDrugs").transform.parent = Instantiate(Drug, new Vector3(-2.18f + i, 0f + i, 9.47f), Drug.rotation);
            i = +10;
        }
    }

}
