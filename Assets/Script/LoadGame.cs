/*************************          PharmEd 
 *                              Comprhensive Project
 *                                  9/04/2018
 *                                  Description
 *               This class is named "LoadGame". "LoadGame" inherits from a base class named "Monobehaviour". 
 *               There are some purposes to this class. First, it is used to initialize the game scene. This is done under the start method.
 *               Second, it is used to collect objects that the player is gazing at. This can be found in the update method. Third, the drugs or
 *               pills on the scene are initialized with attributes (information that the player needs to know about). 
 *                                  Modification
 *               Need to make the input of drug lists dynamic by integrating database or a txt.file
 *               
 *************************/               



using UnityEngine;

public class LoadGame : MonoBehaviour {

    public static GameObject ObjectInFocus = null;                                                             //Global variable to store what object the user is looking at

    // Use this for initialization. This method is called at the very begining of the runtime. 
    void Start ()
    {
        Game Game = new Game();
        Game.SetGame();	
	}//end Start
	
	// Update is called once per frame
	void Update () {


        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);                       /* A ray being defined with start position and direction. 
                                                                                                                   This ray shoots out of the hololens and to the object*/
        RaycastHit RayCastInfo;                                                                                          // a variable to store what the ray hit
        Physics.Raycast(ray, out RayCastInfo);

        if (Physics.Raycast(ray, out RayCastInfo))                                                                    // Storing the game object that is being hit
        {
            LoadGame.ObjectInFocus = RayCastInfo.transform.gameObject;
            

            /****************Feature Modification to implement to display hint based on difficulity level ************************/

            // DisplayHint();                                                                                                               
        }
        else
            return;
    }//end update
  
}
