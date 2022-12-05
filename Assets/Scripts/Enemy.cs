using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 5f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 8, 0);
    }
 
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 8, 0);
        }
    }
}
