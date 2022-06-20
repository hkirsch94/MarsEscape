using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Eyetracking : MonoBehaviour
{
    public Transform rayCast;
    [SerializeField]
    private float threshold;
    private float time = 0.5F;

    private GameObject[] watchable;
    private string look_object;

    private List<string> names;
    private List<float> duration;
    private List<float> since_start;

    private bool saved = false;

    public void Start()
    {
        names = new List<string>() { };
        duration = new List<float>() { };
        since_start = new List<float>() { };
    }




    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
        {
            // Bit shift the index of the layer (8) to get a bit mask
            LayerMask mask = LayerMask.GetMask("Eyetracking");
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(rayCast.transform.position, rayCast.transform.forward, out hit, 20f , mask))
            {
                if (look_object != hit.collider.gameObject.name)
                {
                    this.AddToList();
                }
                look_object = hit.collider.gameObject.name;
                time += Time.deltaTime;
                
            
            }
            else
            {
                this.AddToList();
            }

            if (Input.GetKey(KeyCode.R) && !saved)
            {
                this.CreateFile();
                saved = true;
            }
        }

    public void AddToList()
    {
        if (time > threshold)
        {
            names.Add(look_object);
            duration.Add(time);
            since_start.Add(Time.realtimeSinceStartup);

        }
        time = 0;
    }

    public void CreateFile()
    {
        string path = "data/test.txt";

        StreamWriter File = new StreamWriter(path);
        File.WriteLine("Name; Duration; Time ");
        for (int i = 0; i < names.Count; i++)
        {
            File.WriteLine(names[i] + " ; " + duration[i] + " ; " + since_start[i]);
        }        
        File.Close();


        Debug.Log("Data  saved in data\\test.txt");
    }

}
