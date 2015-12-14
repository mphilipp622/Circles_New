using UnityEngine;
using System.Xml;
using System.Xml.Linq;  
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static SceneManager manager = null;									// Creates a single, global instance of SceneManager.
	public TextAsset chapterText;												// Public interface for the XML document.
	public string chapterData;
	Animator animator;


	// Use this for initialization
	void Awake () {
		if(manager == null)
			manager = this;
		else if(manager != this)
			Destroy(gameObject);												// This checks to see whether an instance of SceneManager already exists.

		chapterData = SceneManager.manager.chapterText.name.Trim();
		DontDestroyOnLoad(gameObject);											// SceneManager will stay throughout all the scenes.
	}




}
