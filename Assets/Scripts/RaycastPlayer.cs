using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayer : MonoBehaviour
{
    public Transform rayCast;
    [SerializeField]
    public RectTransform point;


// See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        LayerMask mask = LayerMask.GetMask("Button");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f , mask))
        {
            point.sizeDelta = new Vector2(6, 6);
        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }
}
