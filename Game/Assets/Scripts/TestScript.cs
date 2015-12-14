using UnityEngine;
using System.Xml;
using System.Collections;

public class TestScript : MonoBehaviour {

	public TextAsset myData;
	public string myString;

	// Use this for initialization
	void Start () {
		myString = SceneManager.manager.chapterData;
		Debug.Log(myString);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
