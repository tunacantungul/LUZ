using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorToggleGroup : MonoBehaviour
    {
        [SerializeField] private DoorToggle[] _doorToggles;
        public Door door;
        
        private int _expectedToggleIndex;
        
        private void Awake()
        {
            InitializeToggles();
        }

        private void InitializeToggles()
        {
            foreach (var doorToggle in _doorToggles)
            {
                doorToggle.OnToggleActivated += () => OnDoorToggle(doorToggle);
            }
        }

        private void OnDoorToggle(DoorToggle doorToggle)
        {
            Debug.Log("OnDoorToggle");
            
            var index = Array.IndexOf(_doorToggles, doorToggle);
            Debug.Log($"index: {index}");
            
            // Wrong toggle order
            if (index != _expectedToggleIndex)
            {
                Debug.Log("wrong toggle order");
                ResetToggleGroup();
                return;
            }
            
            _expectedToggleIndex++;
            Debug.Log("ExpectedtoggleIndex: " + _expectedToggleIndex);
            // Toggle group successfully activated
            if (_expectedToggleIndex == _doorToggles.Length)
            {
                PerformToggleGroupAction();
            }
        }

        private void ResetToggleGroup()
        {
            _expectedToggleIndex = 0;

            foreach (var doorToggle in _doorToggles)
            {
                doorToggle.ResetToggle();
            }
        }

        public void PerformToggleGroupAction()
        {
            _expectedToggleIndex = 0;
            Debug.Log("Toggle group action performed");

            if (door != null)
            {
                door.ToggleDoor();
            }
            else
            {
                Debug.LogWarning("No door found");
            }
        }
    }
}