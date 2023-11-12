using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BublesScript : MonoBehaviour
{
    private bool isGoingUp = true;
    private float timer = 0;
    public float timeInterval = 2;

    public float travelDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeInterval){ 
            timer += Time.deltaTime; 
        } else {
            timer = 0;
            moveInDifferentDirection();
        }
        if (isGoingUp) {
            transform.position = transform.position + (Vector3.up * travelDistance) * Time.deltaTime;
        }
        else {
            transform.position = transform.position + (Vector3.down * travelDistance) * Time.deltaTime;
        }

    }

    void moveInDifferentDirection()
    {
        if (isGoingUp) {
            isGoingUp = false;
        } else {
            isGoingUp = true;
        }
    }
}
