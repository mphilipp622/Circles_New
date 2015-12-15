using UnityEngine;
using System.Collections;

public class SendXMLQuads : MonoBehaviour {

	Animator quads;
	bool quadOneActive = true, quadTwoActive = false;
	int currentQuad, nextQuad;

	bool nextPage = false;
	
	int pageNum = 0;
	
	void Start () {

		quads = GetComponent<Animator>();
		//currentQuad = Loader.Instance.data[1].quadNum;

	}

	void Update () {


		if (nextPage) 
		{
			ChangeQuads ();
			nextPage = false;
		}

	}

	void ChangeQuads()
	{

		//nextQuad = Loader.Instance.data[pageNum].quadNum;

		if(currentQuad != nextQuad && quadOneActive)
		{
			quads.SetTrigger ("Char 1 Fade Out");
			//currentQuad = Loader.Instance.data[pageNum].quadNum;
			quadOneActive = false;
			quadTwoActive = true;
		}
		else if(currentQuad != nextQuad && quadTwoActive)
		{
			quads.SetTrigger ("Char 1 Fade In");
			//currentQuad = Loader.Instance.data[pageNum].quadNum;
			quadTwoActive = false;
			quadOneActive = true;
		}


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
