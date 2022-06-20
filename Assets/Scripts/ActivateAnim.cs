using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnim : MonoBehaviour
{
    //Raycast to get a Object
    [SerializeField]
    private Transform rayCast;
    //For the animation we want to activate on pressing E
    Animator anim;
    //Second Animation we want to start on pressing a button
    [SerializeField]
    private Animator anim_a;
    //Canvas Point which is bigger while watching a object.
    private RectTransform point;
    //ActivateAnim Script to change activated bool so we are just able to activate once
    private ActivateAnim animObject;
    [SerializeField]
    private bool activated = false;

    //Get the components which are new to the scene, like the player
    void Start()
    {
        point = GameObject.Find("PointButton").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        //Layer which we want to hit
        LayerMask mask = LayerMask.GetMask("Button");
        RaycastHit hit;
        // true if the raycast hits specified layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            // get the objects which are git
            anim = hit.collider.GetComponent<Animator>();
            animObject = hit.collider.GetComponent<ActivateAnim>();
            //resets the Active bool defined in the animator so the animation can start again after pressing E
            anim.ResetTrigger("Active");
            //canvas Point which is bigger while raycast hits the layer else its goes back to its normal size
            point.sizeDelta = new Vector2(6, 6);
            //if we press the button and the object was not already activated, the animation of the second object starts
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!animObject.activated)
                {
                    animObject.anim_a.SetTrigger("Active");
                }
                // animation of button ca be repeated
                anim.SetTrigger("Active");
                // bool to block the second animation
                animObject.activated = true;
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
