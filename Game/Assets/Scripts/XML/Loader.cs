using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;  

public class Loader : MonoBehaviour {

	XDocument xmlDoc;
	IEnumerable<XElement> items;
	public List <XMLData> data = new List <XMLData>();
	int iteration = 1;
	//int pageNum = 0;
	//string charText, dialogueText;
	//AudioClip soundClip, musicClip;
	bool finishedLoading = false;
	public static Loader Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	void Start () {
		//DontDestroyOnLoad (gameObject);
		LoadXML ();
		data.Add(new XMLData());
		StartCoroutine ("AssignData");
	}

	void Update () {
		if (finishedLoading) 
		{
			Application.LoadLevel ("Main");
			finishedLoading = false;
		}
	}

	void LoadXML()
	{
		xmlDoc = XDocument.Load( "Assets/Resources/Data/chapter_1.xml" );
		items = xmlDoc.Descendants( "page" ).Elements (); 
	}

	IEnumerator AssignData()
	{
		foreach (var item in items) 
		{
			
			if(item.Parent.Attribute("number").Value == iteration.ToString ())
			{
				/*
				pageNum = int.Parse (item.Parent.Attribute ("number").Value);
				charText = item.Parent.Element("name").Value.Trim ();
				dialogueText = item.Parent.Element ("dialogue").Value.Trim ();
				musicClip = Resources.Load ("Music/" + item.Parent.Element ("music").Value.Trim ().ToString ()) as AudioClip;
				soundClip = Resources.Load ("SFX/" + item.Parent.Element ("SFX").Value.Trim ().ToString ()) as AudioClip;
				*/

				data.Add (new XMLData(int.Parse (item.Parent.Attribute ("number").Value), item.Parent.Element("name").Value.Trim (),
				                      item.Parent.Element ("dialogue").Value.Trim (), 
				                      Resources.Load ("Audio/Music/" + item.Parent.Element ("music").Value.Trim ().ToString ()) as AudioClip, 
				                      Resources.Load ("Audio/SFX/" + item.Parent.Element ("SFX").Value.Trim ().ToString ()) as AudioClip));

				//data.Add (new XMLData(pageNum, charText, dialogueText, musicClip, soundClip));
				iteration++;
			}
		}
		finishedLoading = true;
		yield return null;
	}
}
