using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;
    [SerializeField]
    private Text _pointstext;
    [SerializeField]
    private Text _statustext;
    [SerializeField]
    public MeshRenderer PLS;
    






    public bool gameOver(int points)
    {

        // activate white background for text
        //_whitebackground.GetComponent<Image>().enabled = true;

        _statustext.text = "Game Over \n you collected " + points + " food items! Press E to Continue!";
        PLS.enabled = true;
        if (points >= 10)
        {
            _statustext.color = Color.blue;

        }
        else
        {
            _statustext.color = Color.red;
        }

        return true;

    }

    public bool win()
    {
        PLS.enabled = true;
        _statustext.text = "You collected all 20 food items! Press E to Continue!";
        _statustext.color = Color.green;

        return true;
    }







    // Lives
    public void UpdateLives(int health)
    {
        _livestext.text = "lives: "+ health;
    }

    // Points
    public void UpdatePoints(int points)
    {
        _pointstext.text = "points: " + points;
    }



}
