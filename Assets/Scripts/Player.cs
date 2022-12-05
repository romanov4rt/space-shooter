using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private sbyte _pPos = -1;
    [SerializeField] private sbyte _pSpeed = 5;
    [SerializeField] private GameObject _laserPref;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = 0;

    void Start()
    {
        transform.position = new Vector3 (0, _pPos, 0);
    }

    void Update()
    {
        CalculateMovement();
        FireLaser();        
    }

    void FireLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate (direction * _pSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 3), 0);

        if (transform.position.x > 11.26f)
        {
            transform.position = new Vector3(-11.26f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.26f)
        {
            transform.position = new Vector3(11.26f, transform.position.y, 0);
        }
    }
}
