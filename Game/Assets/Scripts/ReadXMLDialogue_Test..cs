using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;  
using UnityEngine.UI;


public class ReadXMLDialogue_Test : MonoBehaviour {

    // textWriter object to parse text. 
    public TextWriter textWriter;

	XDocument xmlDoc;
	IEnumerable<XElement> dialogues;
	Text dialogueUI;
	bool nextPage = false;
	
	int pageNum = 0;

	
	void Start () 
	{
		LoadXML ();
		dialogueUI = GetComponent<Text> ();
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
		dialogues = xmlDoc.Descendants( "page" ).Elements ();  //Breaks down the XML file's elements. This is used to determine what data to grab 
	}

	void LoadDialogue()
	{
		/*int i = 0;
		var dialogues = xmlDoc.Descendants( "dialogue" );             
		foreach ( var dialogue in dialogues )             
		{      
			dialogueText.Add(dialogue.Value.Trim ());
			//Debug.Log (dialogueText[i]);
			i++;
		} */




	}

	void DisplayText()
	{
		
		foreach ( var dialogue in dialogues )             
		{      
			// is the element named "dialogue" and is it a child of the current page number?
			if(dialogue.Name == "dialogue" && dialogue.Parent.Attribute("number").Value == pageNum.ToString ())
			{
                //Debug.Log (dialogue.Value.Trim ());
                //dialogueText.Add(dialogue.Value.Trim ());
                //dialogueUI.text = dialogue.Value.Trim ();

                // Typewriter Test. 0 = Normal Effect, 1 = Typewriter.
                textWriter.parseText(dialogue.Value.Trim(), dialogueUI, 1);
			}
		} 

		//pageNum++;
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
