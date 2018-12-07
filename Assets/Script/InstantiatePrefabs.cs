using UnityEngine;

public class InstantiatePrefabs: MonoBehaviour
{
    //public  Transform MultipleChoiceA, MultipleChoiceB, MultipleChoiceC;
    GameObject ObjectInFocus;
    public  void Start()
    {
        //Instantiate(MultipleChoiceA, new Vector3(1.33f, -1.6609f, 17.856f), MultipleChoiceA.rotation);
        //Instantiate(MultipleChoiceB, new Vector3(-2.49f, -1.6609f, 17.856f), MultipleChoiceB.rotation);
        //Instantiate(MultipleChoiceC, new Vector3(5.47f, -1.6609f, 17.856f), MultipleChoiceC.rotation);




      
    }

    public void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);                       /* A ray being defined with start position and direction. 
                                                                                                                   This ray shoots out of the hololens and to the object*/
        RaycastHit RayCastInfo;                                                                                          // a variable to store what the ray hit
        Physics.Raycast(ray, out RayCastInfo);

        if (Physics.Raycast(ray, out RayCastInfo))                                                                    // Storing the game object that is being hit
        {
            ObjectInFocus = RayCastInfo.transform.gameObject;
            //Debug.Log(ObjectInFocus.name);
        }
        else
        {
           // Debug.Log(ObjectInFocus.name);
            return;
        }
    }

}
