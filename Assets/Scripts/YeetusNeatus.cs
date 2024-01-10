using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetusNeatus : MonoBehaviour
{
    private float forwardForce = 20;
    private float upForce = 20;
    private Rigidbody rb;
    private float destroyDelay = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.up * upForce, ForceMode.Impulse);
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
