using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    [SerializeField]
    private string scene;
    [SerializeField]
    private Material mat1;

    private void OnTriggerEnter(Collider other)
    {
        //change scene ofter player enters the object
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = mat1;
            SceneManager.LoadScene(scene);
        }
    }

}
