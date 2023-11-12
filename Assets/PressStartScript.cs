using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStartScript : MonoBehaviour
{
    private bool isGoingUp = true;
    private float timer = 0;
    public float timeInterval = 2;

    public float sizeIncrementation = 0.1f;

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
            transform.localScale += new Vector3(sizeIncrementation,sizeIncrementation,0);
        }
        else {
            transform.localScale -= new Vector3(sizeIncrementation,sizeIncrementation,0);
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

