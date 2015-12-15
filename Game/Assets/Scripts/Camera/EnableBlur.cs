using UnityEngine;
using System.Collections;

public class EnableBlur : MonoBehaviour {

	private MonoBehaviour blurScript;
	// Use this for initialization
	void Start () {
		blurScript = gameObject.GetComponent("Blur") as MonoBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space))
			blurScript.enabled = true;
		else if(Input.GetButtonDown ("Fire1"))
			blurScript.enabled = false;
	}
}
