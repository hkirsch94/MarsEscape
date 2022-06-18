using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle_Behaviour : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);
        if (transform.position.y > 20f)
        {
            Destroy(this.gameObject);
        }

    }

}
