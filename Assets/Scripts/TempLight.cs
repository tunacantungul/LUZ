using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempLight : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        Invoke("DestroyMe", 5f);    
    }

    private void Update()
    {
        if (transform.localScale.x == 0)
        {
            Destroy(gameObject);
        }
    }

    void DestroyMe()
    {
        animator.SetTrigger("Disappear");
        Destroy(gameObject);
    }
    
    
}
