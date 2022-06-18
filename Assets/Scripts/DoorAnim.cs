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
        LayerMask mask = LayerMask.GetMask("InteractableObject");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            anim = hit.collider.GetComponent<Animator>();
            anim.ResetTrigger("Active");
            point.sizeDelta = new Vector2(6, 6);
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
