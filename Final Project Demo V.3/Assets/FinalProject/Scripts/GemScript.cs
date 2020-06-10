using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private GameObject gemSpawner;
    public GemSpawn gemSpawn;
    public float velocity;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gemSpawner = GameObject.FindGameObjectWithTag("GemSpawner");
        gemSpawn = gemSpawner.GetComponent<GemSpawn>();
        velocity = gemSpawn.velocity;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - velocity, transform.position.y);
    }
}
