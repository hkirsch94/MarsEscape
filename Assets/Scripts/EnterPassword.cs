using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPassword : MonoBehaviour
{
    /*
     * 
     * We want to enter a password
     * 
     */

    private Transform rayCast;
    private RectTransform point;
    //TaskScript where we want to save all values of the tasks
    private TaskValues value;

    //Inputfield where we show our input
    [SerializeField]
    private GameObject inputField;
    //[SerializeField]
    //private GameObject textDisplay;
    //The password we enter
    private string password = "";

    //[0-9] for the input field
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

    //We want to stop the player movement
    [SerializeField]
    private PlayerMovement movement;

    //We want to be able to fail three time so we success or the password input gets blocked
    private int count = 0;
    private bool s = false;
    private bool b = false;

    
    //We want to show on screen if we were succesful or failed
    [SerializeField]
    private Material success;
    [SerializeField]
    private Material blocked;

    //colour of task if we were succesful or failed
    [SerializeField]
    private Text colour;

    //Get components we needed after starting the scene
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
        //If we were not succesfull or failed already we want to get the layer of the object
        if(!(s || b))
        {
            //the layer we want to hit
            LayerMask mask = LayerMask.GetMask("Password");
            RaycastHit hit;
            //true if the layer got hit
            if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 2f, mask))
            {
                //canvas point which is biger if raycast is hitting the object
                point.sizeDelta = new Vector2(6, 6);
                //activate the input Field first and stop the player from moving
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
            //if the inputField is active we want to get the num keys for the input
            if (inputField.activeSelf)
            {
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    //if the pressed button is a number, append to the password
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        int numberPressed = (i + 1) % 10;
                        password += numberPressed.ToString();
                        //Debug.Log(numberPressed);
                        //Debug.Log(password);
                    }
                }
                //Show the entered password
                inputField.GetComponent<InputField>().text = password;
                //true if password is correct
                if (password == "8717")
                {
                    s = true;
                    this.gameObject.GetComponent<MeshRenderer>().material = success;
                    movement.speed = 3;
                    inputField.SetActive(false);
                    colour.color = Color.green;
                    value.SetData(true);
                }
                //blocked after three fails
                else if (count >= 3)
                {
                    b = false;
                    this.gameObject.GetComponent<MeshRenderer>().material = blocked;
                    inputField.SetActive(false);
                    movement.speed = 3;
                    colour.color = Color.red;
                }
                //resets password and adds a fail to the count
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
