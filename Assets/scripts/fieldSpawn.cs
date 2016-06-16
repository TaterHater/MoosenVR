using UnityEngine;
using System.Collections;

public class fieldSpawn : MonoBehaviour {
    public int size;
    public GameObject tile;
    public int[,] filedArr = new int[25,25]; 
	void Start () {
	for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                Instantiate(tile, new Vector3(100-i * 5, 0, 100-j * 5),Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
