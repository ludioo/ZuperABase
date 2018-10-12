using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public Button btnNext;

    private float textSpeed;

	private Queue <string> sentences;

	void Start () {
		sentences = new Queue<string>();
		
	}

	public void StartDialogue (Dialogue dialogue)
	{
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
    {
        btnNext.gameObject.SetActive(false);
        if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		
	    string sentence = sentences.Dequeue();
	    StopAllCoroutines();
	    StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
        btnNext.gameObject.SetActive(true);
	}
	void EndDialogue()
	{
        FindObjectOfType<LoadScene>().SceneLoader(1);
	}


	
}
