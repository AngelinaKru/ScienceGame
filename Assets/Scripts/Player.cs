using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public Animator treeAnimator;
    private float speed = 10f;
    [SerializeField] Sprite[] sprites;
    int arrayInd = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Useful")
        {
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd];
            arrayInd += 1;

        }

        if (other.gameObject.tag == "Harmful")
        {
            if (arrayInd == 0)
                {
                Debug.Log("Try to collect only useful elements!");
                }
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd-2];
            
        }
    }
}
