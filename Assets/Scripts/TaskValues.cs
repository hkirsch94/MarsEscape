using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskValues : MonoBehaviour
{

    /*
     * 
     * Script to save the Values of the Tasks for better access and overview for the endings
     * 
     */


    public int food = 0;
    public bool data = false;
    public int supplies = 0;

    //Setter
    public void SetFoodValue(int value)
    {
        this.food = value;
    }

    public void SetSuppliesValue(int value)
    {
        this.supplies = value;
    }

    public void SetData(bool value)
    {
        this.data = value;
    }


    //Getter
    public int GetFoodValue()
    {
        return this.food;
    }

    public int GetSuppliesValue()
    {
        return this.supplies;
    }

    public bool GetData()
    {
        return this.data;
    }
}
