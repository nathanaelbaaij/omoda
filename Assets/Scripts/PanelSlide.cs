using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlide : MonoBehaviour
{

    public GameObject Panel;
    Animator animator;

    private void Start()
    {
        animator = Panel.GetComponent<Animator>();
    }

    public void SlidePanel()
    {
        Debug.Log("Test");
        bool isOpen = animator.GetBool("Open");

        animator.SetBool("Open", !isOpen);
    }
}
