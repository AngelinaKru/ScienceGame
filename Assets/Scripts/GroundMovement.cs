using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb;


    private void Start()
    {
        Transform seedTransform = transform.Find("Seed");
       
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        
    }

}
