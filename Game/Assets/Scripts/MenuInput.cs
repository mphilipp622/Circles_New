using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown("0"))
			Fader (0);
		else if (Input.GetKeyDown("1"))
			Fader (1);
	}
	
	public void Fader (int fadeChoice)
	{
		if (fadeChoice == 0)
		{
			animator.SetTrigger("Fade Out");
			Debug.Log ("Fade Out");
		}
		else if (fadeChoice ==1)
		{
			animator.SetTrigger("Fade In");
			Debug.Log ("Fade In");
		}
	}
}
