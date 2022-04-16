using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnDie;
    public event UnityAction OnScore;

    public float jumpPower = 3.5f;
    public float maxSpeed = 3.5f;

    Rigidbody2D playerRigid;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            playerRigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (playerRigid.velocity.y > maxSpeed)
        {
            playerRigid.velocity = new Vector2(0, maxSpeed);
        }
        else if (playerRigid.velocity.y < -maxSpeed)
        {
            playerRigid.velocity = new Vector2(0, -maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {      
        Destroy(gameObject, 0.6f);
        OnDie?.Invoke();       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnScore?.Invoke();
    }
}
