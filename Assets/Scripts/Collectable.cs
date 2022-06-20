using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    /*
     * This Scipt gives us the abilitie to collect items with
     * the specified layer and saves the amount of collected items
     * 
     */

    private Transform rayCast;

    // We want to save the values from multiple taks in another script to make it easier triggering the endings
    [SerializeField]
    private TaskValues value;

    private RectTransform point;

    private GameObject i;
    //We want to save the amount of collectd items for different endings
    public int amount = 0;

    //Change the color of the task text according to the amount
    [SerializeField]
    private Text colour;

    //public GameObject destroy;

    //Get player components because he is created in a different scene
    void Start()
    {
        point = GameObject.Find("PointCollect").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        //The layer we want to get hit by the raycast
        LayerMask mask = LayerMask.GetMask("Collect");
        RaycastHit hit;
       
        
        //true if raycast hits specified layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            // The GameObject which got hit
            i = hit.transform.gameObject;
            point.sizeDelta = new Vector2(6, 6);

            //increase amount of collected item, delete the item and colorize the text according to the amount
            if (Input.GetKeyDown(KeyCode.E))
            {
                amount += 1;
                Destroy(i);
                ColorizeText();
            }


        }
        else
        {
            point.sizeDelta = new Vector2(3, 3);
        }
    }
    //Colorizes the text of the task according to the amount
    private void ColorizeText()
    {
        if (amount >= 10)
        {
            colour.color = Color.green;
            value.SetSuppliesValue(2);
        }
        else if (amount >= 5)
        {
            colour.color = Color.yellow;
            value.SetSuppliesValue(1);
        }
        else
        {
            colour.color = Color.red;
        }
    }
}
