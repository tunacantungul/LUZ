using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Beam"))
        {
            animator.SetTrigger("Flickering");
        }
    }
}
