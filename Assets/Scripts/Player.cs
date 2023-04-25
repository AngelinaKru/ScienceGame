using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // public Animator treeAnimator;
    private float speed = 13f;
    [SerializeField] Sprite[] sprites;
    int arrayInd = 0;
   
    private int minimum = 0;
    private int current = 1;

    public ProgressBar progressBar;
    public GameObject congrats;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(transform.position.x < -9.5)
        {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }

        if (transform.position.x > 9.5)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        int progress = minimum + current;
        progressBar.GetCurrentFill(progress);

        if (minimum == 18)
        {
            congrats.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Useful")
        {
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd];
            arrayInd += 1;
            minimum += 1;

        }

        if (other.gameObject.tag == "Harmful")
        {
            if (arrayInd == 0)
                {
                Debug.Log("Try to collect only useful elements!");
                }
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd-2];
            minimum -= 1;
        }
    }


  
}
