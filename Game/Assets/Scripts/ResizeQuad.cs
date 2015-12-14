using UnityEngine;
using System.Collections;

public class ResizeQuad : MonoBehaviour {

	Texture texture;
	float quadHeight;
	float quadWidth;

	// Use this for initialization
	void Start () 
	{
		texture = GetComponent<Renderer>().material.mainTexture;
		quadHeight = Camera.main.orthographicSize * 2.0f;
		quadWidth = quadHeight * Screen.width / Screen.height;
	}
}
