using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ONTap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GestureRecognizer gReconizer = new GestureRecognizer();
        gReconizer.SetRecognizableGestures(GestureSettings.Tap);
        gReconizer.TappedEvent += GReconizer_TappedEvent;
        gReconizer.StartCapturingGestures();
    }
    private void GReconizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Debug.Log(this.name);
    }
    // Update is called once per frame
}
