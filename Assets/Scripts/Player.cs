using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public Animator treeAnimator;
    private float speed = 10f;
    [SerializeField] Sprite[] sprites;

    int arrayInd = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            //transform.Translate(0, 0,1, 0);

        }

        if (other.gameObject.tag == "Harmful")
        {
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd-2];
        }
    }
}
