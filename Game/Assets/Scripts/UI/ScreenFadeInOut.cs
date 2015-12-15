using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	[SerializeField]
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	[SerializeField]
	private bool sceneEnding = false;
	
	private Image fadeUI;
	
	void Awake ()
	{
		fadeUI = GetComponent<Image>();
		if(!fadeUI.enabled)
			fadeUI.enabled = true;
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
		else if(sceneEnding)
			EndScene ();
		if(Input.GetKeyDown (KeyCode.Return)){
			sceneEnding = true;
			//Application.LoadLevelAdditive (2);
		}
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		fadeUI.color = Color.Lerp(fadeUI.color, Color.clear, fadeSpeed * Time.deltaTime);

	}

	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		fadeUI.color = Color.Lerp(fadeUI.color, Color.black, fadeSpeed * Time.deltaTime);

	}

	void CrossfadeToScene()
	{
		fadeUI.color = Color.Lerp (fadeUI.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(fadeUI.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			fadeUI.color = Color.clear;
			fadeUI.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{

		// Make sure the texture is enabled.
		fadeUI.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(fadeUI.color.a >= 0.95f){
			// ... reload the level.
			Application.LoadLevel(2);
			//Application.UnloadLevel(1);
		}
	}
}
