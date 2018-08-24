using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    int z = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        z -= 1;
        gameObject.transform.eulerAngles = new Vector3(0, 0, z);
	}
}
