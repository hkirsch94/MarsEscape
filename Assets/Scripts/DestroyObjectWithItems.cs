using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyObjectWithItems : MonoBehaviour
{
    private Transform rayCast;

    private RectTransform point;

    [SerializeField]
    private bool item = false;
    private GameObject i;
    public GameObject usable;
    [SerializeField]
    private Text color;

    //public GameObject destroy;

    void Start()
    {
        color = GameObject.Find("DestroyBush").GetComponent<Text>();
        point = GameObject.Find("PointDestroy").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Destroy");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
        {
            i = hit.transform.gameObject;
            point.sizeDelta = new Vector2(6, 6);
            if ((i == usable )&& Input.GetKeyDown(KeyCode.E))
            {
                this.item = true;
                Destroy(i);

            }

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
