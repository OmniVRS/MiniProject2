using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5;
    private float rotationSpeed = 20;
    private float verticalInput;
    private float horizontalInput;

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
        rb.AddForce(Vector3.forward * speed * verticalInput * Time.fixedDeltaTime);
        transform.Rotate(Vector3.right * rotationSpeed * horizontalInput * Time.fixedDeltaTime);
    }
}
