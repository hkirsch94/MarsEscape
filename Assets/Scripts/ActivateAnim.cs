using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnim : MonoBehaviour
{
    [SerializeField]
    private Transform rayCast;
    Animator anim;
    [SerializeField]
    private Animator anim_a;
    private RectTransform point;

    private ActivateAnim animObject;
    [SerializeField]
    private bool activated = false;

    void Start()
    {
        point = GameObject.Find("PointButton").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Button");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            anim = hit.collider.GetComponent<Animator>();
            animObject = hit.collider.GetComponent<ActivateAnim>();
            anim.ResetTrigger("Active");

            point.sizeDelta = new Vector2(6, 6);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!animObject.activated)
                {
                    animObject.anim_a.SetTrigger("Active");
                }
                anim.SetTrigger("Active");
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
