using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
