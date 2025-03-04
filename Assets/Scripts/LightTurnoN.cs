using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnoN : MonoBehaviour
{
    [SerializeField] GameObject lightObject; 

    void TurnOn() {
        lightObject.SetActive(true); 
    }

    void TurnOff() {
        lightObject.SetActive(false); 
    }

}
