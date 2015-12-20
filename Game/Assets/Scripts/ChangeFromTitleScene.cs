using UnityEngine;
using System.Collections;

public class ChangeFromTitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}

	public void ChangeScene(int index)
	{
		Application.LoadLevel (index);
	}
}
