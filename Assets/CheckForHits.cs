using UnityEngine;
using System.Collections;

public class CheckForHits : MonoBehaviour {

    private bool seeded;
    
	void Start () {
        
	}
	
	void Update () {
        
	}
    void onCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "tool")
        {
            Debug.Log("hoeDown");
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "seed")
        {
            Debug.Log("planting..");
            seeded = true;
        }
    }
}
