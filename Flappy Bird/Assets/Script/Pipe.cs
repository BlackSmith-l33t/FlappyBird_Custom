using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 3;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update() 
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
