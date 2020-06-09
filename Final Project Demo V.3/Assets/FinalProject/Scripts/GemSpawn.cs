using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGem", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGem()
    {
        Instantiate<GameObject>(gem, new Vector3(16, Random.Range(-1f, 3f), 0), Quaternion.identity);
    }
}
