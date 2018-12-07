using UnityEngine.XR.WSA.Input;
using UnityEngine;

public class MultipleChoiceBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GestureRecognizer gReconizer = new GestureRecognizer();
        gReconizer.SetRecognizableGestures(GestureSettings.Tap);
        gReconizer.TappedEvent += GReconizer_TappedEvent;
        gReconizer.StartCapturingGestures();
    }

    private void GReconizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
       
        Question.CheckAnswer(this.name.ToString());
    }

    private void OnMouseDown()
    {
        Question.CheckAnswer(this.name.ToString());
    }
}
