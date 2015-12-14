using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;  
using UnityEngine.UI;


public class ReadXMLName_Test : MonoBehaviour {
	
	XDocument xmlDoc;
	IEnumerable<XElement> names;
	Text nameUI;
	bool nextPage = false;

	int pageNum = 0;
	
	
	void Start () 
	{
		LoadXML ();
		nameUI = GetComponent<Text> ();
	}
	
	void Update () 
	{
		if (nextPage) 
		{
			DisplayText ();
			nextPage = false;
		}
	}
	
	void LoadXML()
	{
		xmlDoc = XDocument.Load( "Assets/Prototype/Resources/XML Files/circles_test.xml" );
		names = xmlDoc.Descendants( "page" ).Elements ();  //Breaks down the XML file's elements. This is used to determine what data to grab 
	}
	
	void LoadDialogue()
	{
		/*int i = 0;
		var names = xmlDoc.Descendants( "dialogue" );             
		foreach ( var dialogue in names )             
		{      
			dialogueText.Add(dialogue.Value.Trim ());
			//Debug.Log (dialogueText[i]);
			i++;
		} */
		
		
		
		
	}
	
	void DisplayText()
	{
		
		foreach ( var name in names )             
		{      
			// is the element named "dialogue" and is it a child of the current page number?
			if(name.Name == "name" && name.Parent.Attribute("number").Value == pageNum.ToString ())
			{
				//Debug.Log (dialogue.Value.Trim ());
				//dialogueText.Add(dialogue.Value.Trim ());
				nameUI.text = name.Value.Trim ();

			}
		} 
		
		pageNum++;
		//Resources.UnloadUnusedAssets();
	}
	
	public void SetNextPageTrue()
	{
		nextPage = true;
	}

	public void SetPageNumber(int newNum)
	{
		pageNum = newNum;
	}
}
