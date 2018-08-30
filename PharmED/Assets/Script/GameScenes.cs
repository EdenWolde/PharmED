using UnityEngine;
using UnityEngine.SceneManagement;


//A class to travers between the scenes 

public class GameScenes : MonoBehaviour {
    

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }


}








