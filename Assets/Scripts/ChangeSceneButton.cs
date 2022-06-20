using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public Transform rayCast;

    /*
     * By changing the scene to the minigame, we have to deactivate the other 
     * player and activate the player for the minigame and the spawnmanager
     */
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
    //The score fpr the minigame, which we want to use for the different endings
    public int score = 0;



    void Update()
    {
        //The Layer we want to hit
        LayerMask mask = LayerMask.GetMask("SceneButton");
        RaycastHit hit;
        // true if theRaycast hits the layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            //Get the component of theobject hit
            anim = hit.collider.GetComponent<Animator>();
            //Resets the animation
            anim.ResetTrigger("Active");
            //Bigger canvas Point if hit
            point.sizeDelta = new Vector2(6, 6);

            //By pressing e change scene and player
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!this.activated)
                {
                    
                    playerMain.SetActive(false);
                    SceneManager.LoadScene(scene);
                    spawnManager.SetActive(true);
                    player2D.SetActive(true);

                }
                //Button can be pressed repetedly but the minigame can be just started  once
                anim.SetTrigger("Active");
                this.activated = true;
            }
        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }
    //Getter
    public bool getActivated()
    {

        return activated;
    }
}
