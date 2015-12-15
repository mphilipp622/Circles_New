using UnityEngine;
using System.Collections;

public class SendXMLMusicSFX : MonoBehaviour {

	AudioSource musicSource, soundSource;
	string clipNameMusic, clipNameSound;

	bool nextPage = false;
	
	int pageNum = 0;

	// Use this for initialization
	void Start () 
	{

		musicSource = transform.FindChild ("MusicSource").GetComponent<AudioSource> ();

		soundSource = transform.FindChild ("SFXSource").GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (nextPage) 
		{
			//if(musicSource.clip.name != clipName)
				ChangeMusicClip ();

			ChangeSoundClip();

			nextPage = false;
		}
	}

	void ChangeMusicClip()
	{
		if (Loader.Instance.data [pageNum].musicClip != musicSource.clip) 
		{
			musicSource.clip = Loader.Instance.data [pageNum].musicClip;
			clipNameMusic = musicSource.clip.name;
			musicSource.Play();
		}


	}

	void ChangeSoundClip()
	{
		soundSource.clip = Loader.Instance.data [pageNum].soundClip;
		clipNameSound = soundSource.clip.name;
		soundSource.Play();
	}

	public void SetNextPageTrue(){
		nextPage = true;
	}
	
	public void SetPageNumber(int currentPage)
	{
		pageNum = currentPage;
	}	
}
