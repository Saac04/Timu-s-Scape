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
    public AudioSource audioC;
    public List<AudioClip> audioList;
    public Animator animator;
    public Animator npcAnimator;
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
        npcAnimator.SetTrigger("Hablar");
        isStarted = true;
        nameText.text = dialogue.name;
        
        sentences.Clear();


        foreach (string sentence in dialogue.sentences) { sentences.Enqueue(sentence); }

        DisplayNextSentence();
    }

    public void StartDeathDialogue( Dialogue dialogue)
    {
        audioC.Play();

    }

    public void DisplayNextSentence () 
    {
        audioC.Stop();
        audioC.PlayOneShot(audioList[Random.Range(0, audioList.Count)]);

        if (sentences.Count == 0) 
        {
            audioC.Stop();
            EndDialogue();
            return;
        }
        npcAnimator.SetTrigger("Hablar");
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
        Debug.Log("terminamos la muerte");

        animator.SetBool("idDead", false);
        isDeathStarted = false;
    }


}
