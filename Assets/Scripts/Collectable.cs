using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private Transform rayCast;

    [SerializeField]
    private TaskValues value;

    private RectTransform point;

    private GameObject i;

    public int amount = 0;

    [SerializeField]
    private Text colour;

    //public GameObject destroy;

    void Start()
    {
        point = GameObject.Find("PointCollect").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Collect");
        RaycastHit hit;
       
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            i = hit.transform.gameObject;
            point.sizeDelta = new Vector2(6, 6);

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
