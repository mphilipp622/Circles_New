using UnityEngine;
using System.Collections;

public class PageNumber : MonoBehaviour {

	[SerializeField]
	int pageNum = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SendPageNumber()
	{
		BroadcastMessage ("SetPageNumber", pageNum);
	}

	public void IncrementPageNum()
	{
		pageNum++;
	}
}
