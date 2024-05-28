using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;
    public Animator animator;
    public Lava lava;
    private bool speaking = false;



    public void Start()
    {
        manager = FindAnyObjectByType<DialogueManager>();
    }


    public void Update()
    {
        if (speaking)
        {
            lava.ascensionSpeed = 0f;

        } else if (speaking && lava.ascensionSpeed == 0f  ) { return; }

        else if (!speaking && lava.ascensionSpeed == 0f ) { 

            lava.ascensionSpeed = 0.7f; 

        } else if ( !speaking && lava.ascensionSpeed == 0.7f) { return; }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
    public void OnTriggerEnter(Collider other)
    {

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
            speaking = true;
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
            speaking = false;
            manager.EndDialogue();
        }
    }


}


