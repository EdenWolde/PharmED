using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.WSA.Input;


public class Interaction : MonoBehaviour {

    GameObject ObjectInFocus;

    // Use this for initialization
    void Start ()
    {
        
        GestureRecognizer gReconizer = new GestureRecognizer();
        gReconizer.SetRecognizableGestures(GestureSettings.Tap);
        gReconizer.Tapped += GReconizer_Tapped;
        gReconizer.StartCapturingGestures();

    }

    private void GReconizer_Tapped(TappedEventArgs obj)
    {
        if (ObjectInFocus.tag == "Button")
        {
            if (ObjectInFocus.name == "btnQuest")
                Debug.Log("btnQuest");
                    //GameScenes.ChangeScene("SelectLevel");
            else if (ObjectInFocus.name== "btnDrugBox")
                Debug.Log("btnDrugBox");
                   // GameScenes.ChangeScene("DrugBox");
             
        }
        else
            return;
    }

// Update is called once per frame

void Update()
{
    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);                                // A ray being defined with start position and direction
    RaycastHit RayCastInfo;                                                                                          // a variable to store what the ray hit
    Physics.Raycast(ray, out RayCastInfo);

        if (Physics.Raycast(ray, out RayCastInfo))                                                                   //if the ray has hit something
        {
            // ObjectInFocus = EventSystem.current.currentSelectedGameObject.gameObject;                                // Storing the game object that is being hit
            ObjectInFocus = RayCastInfo.transform.gameObject;
            Debug.Log("The Hit Object is *****************" + ObjectInFocus.name);
        }
        else
            return;
}
}

  