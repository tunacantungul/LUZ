using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorToggle : MonoBehaviour
    {
        public event Action OnToggleActivated;

        private bool _isActive = true;
        
        [SerializeField] GameObject lightObject; 

        void TurnOn() {
            lightObject.SetActive(true); 
            Debug.Log("Turned On");
        }

        void TurnOff() {
            lightObject.SetActive(false); 
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive) return;
            if (other.CompareTag("Beam"))
            {
                TurnOn();
                Debug.Log("OnTriggerEnter2D");
                

                _isActive = false;
                OnToggleActivated?.Invoke();
            }
    }


        public void ResetToggle()
        {
            lightObject.SetActive(false); 
            _isActive = true;
        }
    }
}