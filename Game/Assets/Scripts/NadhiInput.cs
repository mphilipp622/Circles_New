using UnityEngine;
using System.Collections;

public class NadhiInput : MonoBehaviour {
	
	Animator animator;
	
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown("1"))
			animator.SetTrigger("nadhi_idle");
		else if (Input.GetKeyDown("2"))
			animator.SetTrigger ("nadhi_grin");
		else if (Input.GetKeyDown("3"))
			animator.SetTrigger ("nadhi_hand_snap");
	}
}
