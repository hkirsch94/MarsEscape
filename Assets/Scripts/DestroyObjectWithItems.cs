using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyObjectWithItems : MonoBehaviour
{
    /*
     * In this script we want to enable to Destroy an object after collecting another
     * 
     */
    private Transform rayCast;

    private RectTransform point;
    
    //Bool if we collected the item
    [SerializeField]
    private bool item = false;
    //Object we want to destroy
    private GameObject i;
    //Item which we need to destory the object
    public GameObject usable;
    //Task text color which is changed after destroying the object
    [SerializeField]
    private Text color;

    //public GameObject destroy;
    //Get the object we want to change from the player
    void Start()
    {
        color = GameObject.Find("DestroyBush").GetComponent<Text>();
        point = GameObject.Find("PointDestroy").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        //Layer which we want to get hit
        LayerMask mask = LayerMask.GetMask("Destroy");
        RaycastHit hit;
        // True if the layer got hit
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            //Object which got hit
            i = hit.transform.gameObject;
            //canvas point which is bigger if layer gets hit
            point.sizeDelta = new Vector2(6, 6);
            //if the item is the item we want to use and we press E, we want to collect it
            if ((i == usable )&& Input.GetKeyDown(KeyCode.E))
            {
                this.item = true;
                Destroy(i);

            }
            //Destroy object if we have the item to destroy the obbject
            if ((i == this.gameObject) && item && Input.GetKeyDown(KeyCode.E))
            {
                color.color = Color.green;
                point.sizeDelta = new Vector2(3, 3);
                Destroy(this.gameObject);
            }
            
            
        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }

}
