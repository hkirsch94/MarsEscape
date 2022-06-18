using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement2D : MonoBehaviour
{
    // camera should follow player = target
    [SerializeField]
    private Transform target;

    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        // initiate first position
        offset = transform.position - target.transform.position;
    }

    // Update is called atthe end of frame
    void LateUpdate()
    {
        // null check
        if(target != null)
        {
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;
        }
        
    }
}
