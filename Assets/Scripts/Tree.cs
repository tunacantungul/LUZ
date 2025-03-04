using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Beam"))
        {
            animator.SetTrigger("Grow");
        }
    }

    void Update()
    {
        bool test;
        test = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Tree"));
        if (test)
        {
            animator.SetTrigger("Grow");
        }
    }
}
