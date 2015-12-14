using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;  
using System.Xml.XPath;
using UnityEngine.UI;

public class ReadXMLBackground_Test : MonoBehaviour {

	//private XmlDocument xmlData;
	Image backgroundUI;
	Sprite backgroundSprite;
	IEnumerable<XElement> backgrounds;
	XDocument xmlDoc;
	bool nextPage = false;
	
	int pageNum = 0;
	
	void Start () 
	{
		LoadXML (); 
		backgroundUI = GetComponent<Image> ();
	}
	
	void Update () 
	{
		if (nextPage) {
			DisplayImage ();
			nextPage = false;
			//backgroundUI.sprite = backgroundSprite;
		}
		
	}

	void LoadXML()
	{
		xmlDoc = XDocument.Load( "Assets/Prototype/Resources/XML Files/circles_test.xml" );
		backgrounds = xmlDoc.Descendants( "page" ).Elements ();  //Breaks down the XML file's elements. This is used to determine what data to grab 
	}
	
	void DisplayImage()
	{

		foreach ( var background in backgrounds )             
		{      
			// is the element named "dialogue" and is it a child of the current page number?
			if(background.Name == "background" && background.Parent.Attribute("number").Value == pageNum.ToString ())
			{
				//This will be used to change sprite. Will have to wait until Arun sends me XML that has file names

				backgroundUI.sprite = Resources.Load <Sprite>( "Art/Backgrounds/" + background.Value.Trim ().ToString ());

				//Maybe This
				//backgroundUI.sprite = Resources.Load (background.Value.Trim ()) as Sprite;
				
			}
		} 
		
		//pageNum++;
		//Resources.UnloadUnusedAssets();
	}
	
	public void SetNextPageTrue(){
		nextPage = true;
	}

	public void SetPageNumber(int newNum)
	{
		pageNum = newNum;
	}
	
}