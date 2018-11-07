using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public Button btnNext;
    public Dialogue dialogue;

    private float textSpeed;

	private Queue <string> sentences;

	void Start () {
        sentences = new Queue<string>();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Init()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameObject.Find("StartButton").gameObject.SetActive(false);
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
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            FindObjectOfType<LoadScene>().SceneLoader(6);
        }
        else if (SceneManager.GetActiveScene().name == "Narasi")
        {
            FindObjectOfType<LoadScene>().SceneLoader(7);
        }

        else if (SceneManager.GetActiveScene().name == "ProfAns")
        {
            FindObjectOfType<LoadScene>().SceneLoader(1);
        }

        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            FindObjectOfType<LoadScene>().SceneLoader(8);
        }

        else
        {

        }
    }


	
}
