using UnityEngine;
using System.Collections;

public class CrossfadeScenes : MonoBehaviour {

	[SerializeField]
	MeshRenderer quad1, quad2, quadBG;
	Color quad1Color, quad2Color, quadBGColor;
	bool transition = false, countdown = false;
	Animator quadAnimator;
	float startTime, waitTime;
	float alpha;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		quadAnimator = GetComponent<Animator>();
		quadAnimator.SetTrigger ("FadeAllIn");
	}

	void Start () 
	{
		
		quad1Color = quad1.material.color;
		quad2Color = quad2.material.color;
		quadBGColor = quadBG.material.color;

	}
	

	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Space))
		{
			gameObject.name = "QuadsOld";
			Application.LoadLevel("Main");
			quadAnimator.SetTrigger("FadeAll");
			startTime = Time.time;
			transition = true;

		}
		if(transition)
		{
			if(quadAnimator.GetCurrentAnimatorStateInfo(0).length != Mathf.Infinity)
			{
				waitTime = startTime + quadAnimator.GetCurrentAnimatorStateInfo(0).length;
				transition = false;
				countdown = true;
			}
		}

		if(countdown)
		{
			if(Time.time >= waitTime)
				Destroy(gameObject);
		}
		/*if(transition)
		{

			if(quad1Color.a > 0.1)
			{
				quad1Color.a -= Time.deltaTime * 1;
				quad1.material.SetColor("_Color", quad1Color);
				if(quad1Color.a <= 0.1)
				{
					quad1Color.a = 0.0f;
					quad1.material.SetColor("_Color", quad1Color);
				}
			}

			if(quad2Color.a > 0.1)
			{
				quad2Color.a -= Time.deltaTime * 1;
				quad2.material.SetColor("_Color", quad2Color);
				if(quad2Color.a <= 0.1)
				{
					quad2Color.a = 0.0f;
					quad2.material.SetColor("_Color", quad2Color);
				}
			}

			if(quadBGColor.a > 0.1)
			{
				quadBGColor.a -= Time.deltaTime * 1;
				quadBG.material.SetColor("_Color", quadBGColor);
				if(quadBGColor.a <= 0.1)
				{
					quadBGColor.a = 0.0f;
					quadBG.material.SetColor("_Color", quadBGColor);
				}
			}
			//quad1.material.SetColor("_Color", new Color(1, 1, 1, 0));
			//quad2.material.SetColor("_Color", new Color (1, 1, 1, 1));
		}*/
	}
}
