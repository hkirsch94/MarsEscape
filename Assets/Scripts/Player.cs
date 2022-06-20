using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10f;

    // time delay
    private float _nextJumpTime = 0f;
    private float cooldownTime = 2f;

    // time delay firing
    private float _nextFireTime = 0f;
    private float FireCooldownTime = 0.5f;


    private int _lives = 3;
    private int _points = 0;

    [SerializeField]
    private UI_Manager _uiManager;

    [SerializeField]
    private Rigidbody RB;

    [SerializeField]
    private GameObject _bulletPrefab;

    private float _colorChannel = 1f;
    private MaterialPropertyBlock _mpb;

    [SerializeField]
    private GameObject SpawnManager;

    [SerializeField]
    private string scene;
    private bool end = false;

    [SerializeField]
    private GameObject playerMain;
    [SerializeField]
    private GameObject player2D;
    [SerializeField]
    private Text color;

    [SerializeField]
    private TaskValues value;


    // Start is called before the first frame update
    void Start()
    {
        _uiManager.UpdateLives(_lives);
        _uiManager.UpdatePoints(_points);



        transform.position = new Vector3(0f, 0f, 0f);

        // color check
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            PlayerMovement();
        }      

        //Bullet firing
        if(Input.GetKeyDown(KeyCode.E) && _nextFireTime < Time.time)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0f,0.65f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + FireCooldownTime;

        }

        //Change back to the main Game, the player and save information according to the reached Points

        if (end && Input.GetKeyDown(KeyCode.E))
        {
            playerMain.GetComponent<ChangeSceneButton>().score = _points;


            SpawnManager.SetActive(false);
            player2D.SetActive(false);
            playerMain.SetActive(true);
            if(_points == 20)
            {
                color.color = Color.green;
                value.SetFoodValue(2);
            }
            else if (_points >= 10)
            {
                color.color = Color.yellow;
                value.SetFoodValue(1);
            }
            else
            {
                color.color = Color.red;
            }
            
            SceneManager.LoadScene(scene);
            
        }

    }

    public void Damage()
    {
        //damage
        _lives --;
        _uiManager.UpdateLives(_lives);
        //Debug.Log("Damage -1, Remaining:" + _lives);

        _colorChannel -= 0.5f;
        _mpb.SetColor("_Color", new Color(_colorChannel, 0f, _colorChannel, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
       

        if(_lives == 0)
        {
            

            if(SpawnManager != null)
            {
                //Destroy(this.gameObject);
                //Debug.Log("Death");

                SpawnManager.GetComponent<Spawnmanager>().onPlayerDeath();
            }
            else
            {
                Debug.LogError("Spawnmanager not assigned");
            }

            foreach (Transform child in SpawnManager.transform)
            {
                Destroy(child.gameObject);
            }

            SpawnManager.GetComponent<Spawnmanager>().onPlayerDeath();
            end = _uiManager.gameOver(_points);

        }

    }


    public void Points()
    {
        //points
        _points++;
        _uiManager.UpdatePoints(_points);
        //Debug.Log("Points +1, Remaining:" + _points);



        if (_points == 20)
        {
            if (SpawnManager != null)
            {
                //Destroy(this.gameObject);
                //Debug.Log("Death");
                SpawnManager.GetComponent<Spawnmanager>().onPlayerDeath();
            }
            else
            {
                Debug.LogError("Spawnmanager not assigned");
            }

            foreach (Transform child in SpawnManager.transform)
            {
                Destroy(child.gameObject);
            }


            SpawnManager.GetComponent<Spawnmanager>().onPlayerWin();
            end = _uiManager.win();
        }



    }







    void PlayerMovement()
    {
        // moving left/right
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);

        // jumping when space is pressed adding a certain time delay
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + cooldownTime;

        }

        // teleport back to start if falls below -10
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }



}
