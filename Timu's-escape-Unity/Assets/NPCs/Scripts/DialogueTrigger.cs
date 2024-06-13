using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;
    public Animator animator;
    public Lava lava;
    private bool speaking = false;
    private int sceneId;




    public void Start()
    {
        manager = FindAnyObjectByType<DialogueManager>();
        if (lava == null){ Debug.Log("No hay lava asociada al dialogo");}

        UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();

        // Get the build index (ID) of the active scene
        sceneId = activeScene.buildIndex;

    }


    public void Update()
    {
        if (lava == null) { return; }

        if (speaking)
        {
            lava.ascensionSpeed = 0f;

        } else if (speaking && lava.ascensionSpeed == 0f  ) { return; }

        else if (!speaking && lava.ascensionSpeed == 0f ) { 

            lava.ascensionSpeed = 0.6f; 

        } else if ( !speaking && lava.ascensionSpeed == 0.7f) { return; }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (sceneId == 1)
            {
                Invoke("TriggerDialogue", 1); // Call MyFunction after 3 seconds
            } else
            {
                TriggerDialogue();
            }
        } else if (other.CompareTag("Lava"))
        {

            if (animator != null)
            {
                animator.SetTrigger("Die");
            }

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

            if (animator != null){
                animator.SetTrigger("Backflip");
            }
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


