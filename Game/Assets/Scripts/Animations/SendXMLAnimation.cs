using UnityEngine;
using System.Collections;

public class SendXMLAnimation: MonoBehaviour {

	Animator currentAnimation, quads;
	[SerializeField]
	Animator animationOne, animationTwo;
	string currentAnimName, nextAnimName;
	bool quadOneActive = true, quadTwoActive = false;
	int currentQuad, nextQuad;

	bool nextPage = false;
	
	int pageNum = 0;
	
	void Start () {

		if(animationOne == null)
		{
			animationOne = transform.FindChild("nadhi_1_test").GetComponent<Animator>();
		}

		if(animationTwo == null)
		{
			animationTwo = transform.FindChild ("nadhi_2_test").GetComponent<Animator>();
		}

		quads = GameObject.Find("Quads").GetComponent<Animator>();
		
	}
	
	void Update () {
		
		
		if (nextPage) 
		{
			ChangeAnimation ();
			nextPage = false;
		}
		
	}
	
	void ChangeAnimation()
	{
		
		nextAnimName = Loader.Instance.data[pageNum].animationName;
		
		if(currentAnimName != nextAnimName)
		{
			ChangeQuads ();
			currentAnimation.SetTrigger (Loader.Instance.data[pageNum].animationName);
			currentAnimName = Loader.Instance.data[pageNum].animationName;

		}
		
		
	}

	void ChangeQuads()
	{

		
		if(quadOneActive)
		{
			currentAnimation = animationTwo;
			quads.SetTrigger ("Char 1 Fade Out");
			quadOneActive = false;
			quadTwoActive = true;
		}
		else if(quadTwoActive)
		{
			currentAnimation = animationOne;
			quads.SetTrigger ("Char 1 Fade In");
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
