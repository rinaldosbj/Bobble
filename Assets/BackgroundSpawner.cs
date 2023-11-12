using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject background;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnBg();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){ 
            timer += Time.deltaTime; 
        } else {
            timer = 0;
            spawnBg();
        }
    }

    void spawnBg()
    {
        Instantiate(background, transform.position, transform.rotation);
    }

    
}

