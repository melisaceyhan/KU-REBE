using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;
    private Queue<string> sentences;
    private int texts= 0;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        texts += 1;

        if (texts == 18)
        {
            StartCoroutine(GoToRegister());
        }
    }

    IEnumerator GoToRegister()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Register");
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(0.01f);
            dialogueText.text += letter;
            yield return null;
        }
    }

}