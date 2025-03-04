using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCreation : MonoBehaviour
{
    [SerializeField] GameObject lightPrefab;
    

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(lightPrefab, mousePos, Quaternion.identity);
        }
    }
}
