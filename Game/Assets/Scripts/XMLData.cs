using UnityEngine;
using System.Collections;

public class XMLData {

	public int pageNum;
	public string charText, dialogueText;
	public AudioClip musicClip, soundClip;
	
	public XMLData (int page, string character, string dialogue, AudioClip music, AudioClip sound)
	{
		pageNum = page;
		charText = character;
		dialogueText = dialogue;
		musicClip = music;
		soundClip = sound;
	}

	public XMLData()
	{
		pageNum = 0;
		charText = null;
		dialogueText = null;
		musicClip = null;
		soundClip = null;
	}
}
