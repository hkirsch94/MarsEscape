using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public Transform rayCast;
    Animator anim;

    [SerializeField]
    public RectTransform point;

    void Update()
    {
        //The layer we want to get hit
        LayerMask mask = LayerMask.GetMask("InteractableObject");
        RaycastHit hit;
        // true if the layer got hit
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            //get the animator of the object we want to activate
            anim = hit.collider.GetComponent<Animator>();
            //Resets the Active bool of the animator so we can use the door repeatedly
            anim.ResetTrigger("Active");
            //biger canvas point if raycast hits the specified layer
            point.sizeDelta = new Vector2(6, 6);
            //Start the animation by pressing E
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                anim.SetTrigger("Active");
         
            }
        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }
}
