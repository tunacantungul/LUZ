using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLight : MonoBehaviour
{
    [SerializeField] Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        {
            animator.SetTrigger("Flickering");
        }
    }
}
