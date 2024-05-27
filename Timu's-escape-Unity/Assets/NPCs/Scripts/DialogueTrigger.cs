using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;
    public Animator animator;

    public void Start()
    {
        manager = FindAnyObjectByType<DialogueManager>();
    }
    public void OnTriggerEnter(Collider other)
    {

        Debug.Log(other);

        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        } else if (other.CompareTag("Lava"))
        {
            Debug.Log("se toco la lava");
            TriggerDeathDialogue();
        }

    }

    

    public void OnTriggerExit(Collider other)
    {
        EndDialog();
    }

    public void TriggerDialogue ()
    {

        if (manager  != null )
        {
            manager.StartDialogue(dialogue);

            animator.SetTrigger("Backflip");
        }
        
    }

    public void TriggerDeathDialogue()
    {

        if (manager != null)
        {
            manager.StartDeathDialogue(dialogue);
        }

    }

    public void EndDialog()
    {

        if (manager != null)
        {
            manager.EndDialogue();
        }
    }


}


