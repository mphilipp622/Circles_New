using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {

	private Camera cam;

	void Awake()
	{

	}

	void Start () 
	{
		//Screen.SetResolution (1368, 768, false);
		cam = Camera.main;
		cam.aspect = 16f / 9f;
		cam.orthographicSize = 768f / (2f * 100f);

	}

	void Update () 
	{

	}
}
