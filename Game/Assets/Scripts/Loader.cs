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
	List <XMLData> data = new List <XMLData>();
	int iteration = 1, pageNum = 0;
	string charText, dialogueText;
	AudioClip soundClip, musicClip;
	bool finishedLoading = false;


	void Start () {
		LoadXML ();
		//chapterName = SceneManager.manager.chapterText.name.Trim();
		data.Add(new XMLData());
		StartCoroutine ("AssignData");

		//XMLData[] dataArray = data.ToArray ();
		//Debug.Log (dataArray [3].pageNum);
	}

	void Update () {
		if (finishedLoading) 
		{
			Application.LoadLevel ("Title");
			finishedLoading = false;
		}
	}

	void LoadXML()
	{
		xmlDoc = XDocument.Load("Assets/Data/chapter_1.xml");
		items = xmlDoc.Descendants( "page" ).Elements (); 
	}

	IEnumerator AssignData()
	{
		foreach (var item in items) 
		{
			
			if(item.Parent.Attribute("number").Value == iteration.ToString ())
			{
				pageNum = int.Parse (item.Parent.Attribute ("number").Value);
				charText = item.Parent.Element("name").Value.Trim ();
				dialogueText = item.Parent.Element ("dialogue").Value.Trim ();
				musicClip = Resources.Load ("Assets/Audio/Music/" + item.Parent.Element ("music").Value.Trim ().ToString ()) as AudioClip;
				soundClip = Resources.Load ("Assets/Audio/SFX/" + item.Parent.Element ("SFX").Value.Trim ().ToString ()) as AudioClip;
				
				/*switch (item.Parent.Name.ToString ())
				{
				case "name":
					charText = item.Value.Trim ();
					break;
					
				case "dialogue":
					dialogueText = item.Value.Trim ();
					break;
					
				case "music":
					musicClip = Resources.Load ("Music/" + item.Value.Trim ().ToString ()) as AudioClip;
					break;
					
				case "SFX":
					soundClip = Resources.Load ("SFX/" + item.Value.Trim ().ToString ()) as AudioClip;
					break;
				}*/
				
				data.Add (new XMLData(pageNum, charText, dialogueText, musicClip, soundClip));
				//Debug.Log (data[iteration].musicClip.name);
				iteration++;
			}
		}

		finishedLoading = true;
		yield return null;
	}
}
