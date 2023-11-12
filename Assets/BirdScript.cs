using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public LogicScript logic;

    public bool isAlive = true;

    public Sprite poped;

    public Sprite normal;

    public Sprite force;

    private float timer = 0;

    public float dlayAnimation = 0;

    public AudioSource audioSource;

    public float flapStrenght;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isAlive){
            myRigidbody.velocity = Vector2.down * flapStrenght;
            gameObject.GetComponent<SpriteRenderer>().sprite = force;
            timer = 0;
        }

        if ((transform.position.y < -1 || transform.position.y > 1) && isAlive)
        {
            birdDied();
        }
        
        if (timer < dlayAnimation){ 
            timer += Time.deltaTime; 
        } else if (gameObject.GetComponent<SpriteRenderer>().sprite == force) {
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (isAlive) {
            birdDied();
        }
    }

    private void birdDied() {
        logic.gameOver();
        isAlive = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = poped;
        audioSource.Play();
    }
}
