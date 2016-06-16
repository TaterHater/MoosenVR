using UnityEngine;
using System.Collections;

public class controllergrab : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;
    public GameObject cntrller;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);
        if (triggerButtonDown)
        {
            Debug.Log("trigger down!");
        }
        }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("collider down!"+c.tag);
        if (triggerButtonPressed)
        {
            Debug.Log("down in collider" + c.tag);

            c.gameObject.transform.SetParent(cntrller.transform);
            c.GetComponent<Rigidbody>().isKinematic = true;
            c.gameObject.transform.Translate(new Vector3(0, 0, 0));

        }
        else
        {
            c.gameObject.transform.SetParent(null);
            c.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
