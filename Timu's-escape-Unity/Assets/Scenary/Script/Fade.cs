using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
    }
    public void FadeIn() {
        animator.Play("FadeIn");
    }
    public void FadeOut() {
        animator.Play("FadeOut");
    }


}
