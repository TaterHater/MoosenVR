using UnityEngine;
using System.Collections;

public class controllergrab : MonoBehaviour
{

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;

    private GameObject tool;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;
    public GameObject cntrller;
    private Collider C;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);
        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);
        if (triggerButtonDown)
        {
            Debug.Log("trigger down!");
        }
        if (gripButtonDown)
        {
            Debug.Log("grip down!");
            if (C != null)
            {
                C.transform.SetParent(null);
                C.GetComponent<Rigidbody>().isKinematic = false;
                C = null;
            }
        }
    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("collider down!" + c.tag);
        if (triggerButtonPressed)
        {
            Debug.Log("down in collider" + c.tag);
            tool = c.GetComponent<GameObject>();
            c.transform.SetParent(cntrller.transform);
            c.GetComponent<Rigidbody>().isKinematic = true;
            C = c;

            c.gameObject.transform.Translate(new Vector3(0, 0, 0));
            //tool = null;

        }

    }
}
