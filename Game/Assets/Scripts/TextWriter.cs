using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This class takes a string and returns it as either a full line, or applies a typewriter effect.

public class TextWriter : MonoBehaviour {

    public void parseText(string textInput, Text textBox, int textChoice)
    {     
        // Reset the Text item to be blank.
        textBox.text = "";

        // 0 = Normal text output.
        // 1 = Typewriter text output. 
        if (textChoice == 0)
        {
            textBox.text = textInput;
        }
        else if (textChoice == 1)
        {
            StartCoroutine(typeWriter(textInput, textBox));
        }
    }

    // typeWriter goes through each character, and adds the character to the Text object.
    IEnumerator typeWriter(string text, Text textTarget)
    {
        foreach (char myChar in text)
        {
            textTarget.text += myChar;
            yield return new WaitForSeconds(0.09f);
        }
    }
}
