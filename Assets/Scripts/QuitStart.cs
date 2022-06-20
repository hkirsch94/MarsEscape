using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitStart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Should end the Game by pressing Excape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
