using UnityEngine;

public class Player : MonoBehaviour
{
    // public Animator treeAnimator;
    readonly float speed = 13f;
    [SerializeField] Sprite[] sprites;
    int arrayInd = 0;

    int minimum = 0;
    readonly int current = 1;

    public ProgressBar progressBar;
    public GameObject congrats;


    void Update()
    {
        if (transform.position.x < -9.5)
        {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }

        if (transform.position.x > 9.5)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right);
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
        if (other.CompareTag("Useful"))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[arrayInd];
            arrayInd += 1;
            minimum += 1;

        }

        if (other.CompareTag("Harmful"))
        {
            if (arrayInd == 0)
            {
                Debug.Log("Try to collect only useful elements!"); // Tämä voisi näkyä pelaajalle. Käytä TextMeshPro:ta
            }
            // Tämä tapahtuu aina kun collidetaan Harmful:iin. Sille pitää saada jokin rajaehto (if (jokin >=0) tms..
                    GetComponent<SpriteRenderer>().sprite = sprites[arrayInd - 2];
                    minimum -= 1;
                
            
        }
    }



}
