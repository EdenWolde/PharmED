/****Eden Woldeselassie
     9/24/2018
     C# Script 
     GameScene Class
     A class to travers between the scenes  *******************/
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScenes : MonoBehaviour
{
    // to change the sences
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void LoadLevel()
    {
        Debug.Log(this.name);
        if (this.name == "btnHENE")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnRenal")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnCardio")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnPulm")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnInfection")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnMuscle")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnEndocrine")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnNeuro")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnGastro")
        {
            Debug.Log(this.name);
        }
        else if (this.name == "btnpain")
        {
            Debug.Log(this.name);
        }
    }
}








