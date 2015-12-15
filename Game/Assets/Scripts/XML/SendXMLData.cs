using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;  
using UnityEngine.UI;

public class SendXMLData : MonoBehaviour {

	[SerializeField]
	TextWriter textWriter;

	Text dialogueUI;
	Text nameUI;

	bool nextPage = false;
	
	int pageNum = 0;

	// Use this for initialization
	void Start () 
	{
		dialogueUI = transform.FindChild ("BottomPanel").FindChild("DialogueText").GetComponent<Text> ();
		textWriter = transform.FindChild ("BottomPanel").FindChild ("DialogueText").GetComponent<TextWriter> ();
		nameUI = transform.FindChild ("BottomPanel").FindChild("NameText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (nextPage) 
		{
			DisplayDialogueText ();
			DisplayNameText();
			nextPage = false;
		}

	}
	void DisplayDialogueText()
	{

		textWriter.parseText(Loader.Instance.data[pageNum].dialogueText, dialogueUI, 1);

	}

	void DisplayNameText()
	{

		nameUI.text = Loader.Instance.data [pageNum].charText;

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
