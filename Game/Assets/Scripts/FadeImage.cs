using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Iterates through children of an object to change their alpha opacties.

public class FadeImage : MonoBehaviour {
	
	public float fadeSpeed;
	bool isFading = false;
	Color renderColor;

	
	// Initialize variables. A fade cannot happen if isFading is currently false.
	void Start () 
	{ 
		
	}

	// 1 = Fade Out, 2 = Fade in.
	public void FadeStart(int selection) 
	{
		StartCoroutine(Fade(selection));
		
	}
	
	
	IEnumerator Fade(int selection) 
	{
		renderColor = GetComponent<Image>().color;
		// Fade In.
		if (selection == 1) 
		{
			isFading = true;
			do 
			{
				renderColor.a = Mathf.Clamp01 (Mathf.MoveTowards(renderColor.a, 0, fadeSpeed * Time.deltaTime));
				GetComponent<Image>().color = renderColor;
				renderColor.a -= fadeSpeed * Time.deltaTime;
				yield return null;
			} while(GetComponent<Image>().color.a != 0 && isFading == true);
			isFading = false;
		}
		// Fade Out.
		if (selection == 2) 
		{
			isFading = true;
			do 
			{
				renderColor.a = Mathf.Clamp01 (Mathf.MoveTowards(renderColor.a, 1, fadeSpeed * Time.deltaTime));
				GetComponent<Image>().color = renderColor;
				renderColor.a += fadeSpeed * Time.deltaTime;
				yield return null;
			} while(GetComponent<Image>().color.a != 1 && isFading == true);
			isFading = false;
		}
		// Debug.Log ("Got here." + GetComponent<Renderer>().material.color + " " + renderColor.a);
	}	
}
