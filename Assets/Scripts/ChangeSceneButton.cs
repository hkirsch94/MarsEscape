using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public Transform rayCast;

    

    Animator anim;
    [SerializeField]
    private RectTransform point;
    [SerializeField]
    private string scene;
    private bool activated = false;
    [SerializeField]
    private GameObject playerMain;
    [SerializeField]
    private GameObject player2D;
    [SerializeField]
    private GameObject spawnManager;

    public int score = 0;



    void Update()
    {
        LayerMask mask = LayerMask.GetMask("SceneButton");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            anim = hit.collider.GetComponent<Animator>();
            anim.ResetTrigger("Active");

            point.sizeDelta = new Vector2(6, 6);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!this.activated)
                {
                    
                    playerMain.SetActive(false);
                    SceneManager.LoadScene(scene);
                    spawnManager.SetActive(true);
                    player2D.SetActive(true);

                }
                anim.SetTrigger("Active");
                this.activated = true;
            }
        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }

    public bool getActivated()
    {

        return activated;
    }
}
