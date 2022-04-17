using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] [Range(1f, 40f)] float speed = 3f;

    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;
    GameObject player;

    private void Start()
    {      
        player = GameObject.Find("Player");
        startPos = transform.position;
    }

    private void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;

        if (null == player)
        {
            GetComponent<BackGround>().enabled = false;
        }
    }
}


