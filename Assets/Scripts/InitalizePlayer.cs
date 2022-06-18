using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitalizePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerMain;
    [SerializeField]
    private GameObject player2D;
    [SerializeField]
    private GameObject spawnManager;

    public GameObject light;

    [SerializeField]
    private string scene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(spawnManager);
        GameObject.DontDestroyOnLoad(player2D);
        GameObject.DontDestroyOnLoad(playerMain);
        GameObject.DontDestroyOnLoad(light);
        playerMain.SetActive(false);
        player2D.SetActive(false);
        spawnManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            playerMain.SetActive(true);
            SceneManager.LoadScene(scene);
                
        }
    }
}
