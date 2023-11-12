using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovementScript : MonoBehaviour
{
    public float travelDistance = 100;
    public float maxHeight = 100;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * travelDistance) * Time.deltaTime;
        if (transform.position.y >= maxHeight) {
            Destroy(gameObject);
        }
    }
}
