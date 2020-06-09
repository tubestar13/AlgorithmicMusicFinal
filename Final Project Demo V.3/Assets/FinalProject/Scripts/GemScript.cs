using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{

    public float velocity;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - velocity, transform.position.y);

        if (transform.position.x < -13)
        {
            gameObject.SetActive(false);
        }
    }
}
