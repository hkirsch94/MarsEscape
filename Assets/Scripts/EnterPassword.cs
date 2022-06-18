using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPassword : MonoBehaviour
{
    private Transform rayCast;
    private RectTransform point;
    private TaskValues value;


    [SerializeField]
    private GameObject inputField;
    //[SerializeField]
    //private GameObject textDisplay;
    private string password = "";

    private KeyCode[] keyCodes = {
        
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0,
     };

    [SerializeField]
    private PlayerMovement movement;

    private int count = 0;
    private bool s = false;
    private bool b = false;

    

    [SerializeField]
    private Material success;
    [SerializeField]
    private Material blocked;

    [SerializeField]
    private Text colour;

    void Start()
    {
        inputField.SetActive(false);
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        value = GameObject.Find("Player").GetComponent<TaskValues>();
        colour = GameObject.Find("SaveData").GetComponent<Text>();
        point = GameObject.Find("PointPassword").GetComponent<RectTransform>();
        rayCast = GameObject.Find("CameraPlayer").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(s || b))
        {
            LayerMask mask = LayerMask.GetMask("Password");
            RaycastHit hit;
            if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
            {
                point.sizeDelta = new Vector2(6, 6);
                if (Input.GetKeyDown(KeyCode.E) && password == "")
                {
                    inputField.SetActive(true);
                    movement.speed = 0;

                }
            }
            else
            {
                point.sizeDelta = new Vector2(3, 3);
            }

            if (inputField.activeSelf)
            {
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        int numberPressed = (i + 1) % 10;
                        password += numberPressed.ToString();
                        //Debug.Log(numberPressed);
                        //Debug.Log(password);
                    }
                }
                inputField.GetComponent<InputField>().text = password;
                if (password == "8717")
                {
                    s = true;
                    this.gameObject.GetComponent<MeshRenderer>().material = success;
                    movement.speed = 3;
                    inputField.SetActive(false);
                    colour.color = Color.green;
                    value.SetData(true);
                }
                else if (count >= 3)
                {
                    b = false;
                    this.gameObject.GetComponent<MeshRenderer>().material = blocked;
                    inputField.SetActive(false);
                    movement.speed = 3;
                    colour.color = Color.red;
                }
                else if (password.Length >= 4)
                {
                    password = "";
                    this.count += 1;
                    inputField.SetActive(false);
                    movement.speed = 3;
                }
            }
            


            


        }

    }
}
