using UnityEngine;
using System.Collections;

public class XMLData {

	public int pageNum;
	public string charText, dialogueText, animationName;
	public AudioClip musicClip, soundClip;
	
	public XMLData (int page, string character, string dialogue, string animation, AudioClip music, AudioClip sound)
	{
		pageNum = page;
		charText = character;
		dialogueText = dialogue;
		animationName = animation;
		musicClip = music;
		soundClip = sound;
	}

	public XMLData()
	{
		pageNum = 0;
		charText = null;
		dialogueText = null;
		animationName = null;
		musicClip = null;
		soundClip = null;
	}
}
