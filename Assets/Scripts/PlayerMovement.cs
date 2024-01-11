using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 3;
    private float rotationSpeed = 80;
    private float verticalInput;
    private float horizontalInput;
    public GameObject projectilePrefab;
    public GameObject bulletSpawn;
    private bool collision;
    private Animator animator;
    private float jumpStrength = 10;
    private bool isInAction;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.fixedDeltaTime);
        animator.SetFloat("Vertical Input", verticalInput);
        if (verticalInput != 0)
        {
            isInAction = true;
            stop = false;
        }

        if (verticalInput == 0 && !stop)
        {
            isInAction = false;
            stop = true;
        }
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.M))
       {
            StartCoroutine("ThrowWithDelay");
       }

       if (Input.GetKeyDown(KeyCode.Space))
       {
            animator.SetTrigger("Jumping");
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
       }
    }

    IEnumerator ThrowWithDelay()
    {
        if (!isInAction)
        {
            isInAction = true;
            animator.SetTrigger("Throw");
            yield return new WaitForSeconds(0.85f);
            Instantiate(projectilePrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            yield return new WaitForSeconds(1f);
            isInAction = false;
        }
    }
}
