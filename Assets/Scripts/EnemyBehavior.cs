using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private Transform playerTF;
    private GameManager gameManager;
    private Animator animator;
    private float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        playerTF = player.GetComponent<Transform>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //animator.SetFloat("Move Speed", moveSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((player.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime, Space.World);
        transform.LookAt(playerTF);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateScore();
            Destroy(gameObject);
        }
    }
}
