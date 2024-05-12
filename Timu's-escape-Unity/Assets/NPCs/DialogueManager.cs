using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private bool isStarted = false;
    private bool isDeathStarted = false;
    private Queue<string> sentences;
    private string deathSentence;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); 
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isStarted)
        {
            DisplayNextSentence();
        }

    }
    public void StartDialogue( Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        isStarted = true;
        nameText.text = dialogue.name;
        
        sentences.Clear();


        foreach (string sentence in dialogue.sentences) { sentences.Enqueue(sentence); }

        DisplayNextSentence();
    }

    public void StartDeathDialogue( Dialogue dialogue)
    {

        Debug.Log("APDPASDPASNDPA");
        animator.SetBool("idDead", true);
        isDeathStarted = true;
        nameText.text = dialogue.name;

        dialogueText.text = dialogue.deathSentence;

        Invoke("EndDeathDialogue", 1f);

    }

    public void DisplayNextSentence () 
    {

        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue ()
    {
        animator.SetBool("isOpen", false);
        isStarted = false;
    }
    public void EndDeathDialogue()
    {
        animator.SetBool("idDead", false);
        isDeathStarted = false;
    }


}