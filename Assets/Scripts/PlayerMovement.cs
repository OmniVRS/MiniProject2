using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 15;
    private float rotationSpeed = 80;
    private float verticalInput;
    private float horizontalInput;
    public GameObject projectilePrefab;
    public GameObject bulletSpawn;
    private bool collision;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(transform.forward * speed * verticalInput * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.fixedDeltaTime);
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.Space))
       {
            Instantiate(projectilePrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
       }
    }
}
