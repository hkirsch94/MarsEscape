using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawnmanager : MonoBehaviour
{
    // VARIABLES
    [SerializeField]
    private GameObject _enemyPrefab;

    private GameObject _foodPrefab;

    [SerializeField]
    private GameObject[] food;
    [SerializeField]
    private UI_Manager _uiManager;

    private float _delay = 1f;
    private bool _counter = false;
    private bool _alive = true;
    private bool _win = false;

    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    private int GetRandomNumber()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, food.Length);
        return randomNumber;
    }



    public void onPlayerDeath()
    {
        _alive = false;

    }

    public void onPlayerWin()
    {
        _win = true;

    }


    IEnumerator SpawnSystem()
    {
        // SPAWNING Enemies + Food
        while (_alive && !_win)
        {
            _counter = !_counter;
            if (_counter)
            {
                _foodPrefab = food[GetRandomNumber()];
                Instantiate(_foodPrefab, transform.position + new Vector3(Random.Range(-25f, 25f), 15f, 0), Quaternion.identity, this.transform);
            }
            Instantiate(_enemyPrefab, transform.position + new Vector3(Random.Range(-25f, 25f), 15f, 0), Quaternion.identity, this.transform);
           
            yield return new WaitForSeconds(_delay);
        }
       

    }
}