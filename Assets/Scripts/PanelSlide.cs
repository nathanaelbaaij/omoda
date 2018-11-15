using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlide : MonoBehaviour {
    
    public GameObject Panel;

    public void SlidePanel()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();

            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }
}
