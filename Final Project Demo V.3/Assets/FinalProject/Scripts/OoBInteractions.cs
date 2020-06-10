using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class OoBInteractions : MonoBehaviour
{
    public  Hv_final_AudioLib pd;
    private float pitch;
    private Collider2D coll;
    private GameObject gemSpawner;
    private GemSpawn gemSpawn;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        gemSpawner = GameObject.FindGameObjectWithTag("GemSpawner");
        gemSpawn = gemSpawner.GetComponent<GemSpawn>();
        pd.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_final_AudioLib.FloatMessage message)
    {
        pitch = message.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            pd.SendEvent(Hv_final_AudioLib.Event.Miss);
            pd.SendEvent(Hv_final_AudioLib.Event.Reset);
            pd.SendEvent(Hv_final_AudioLib.Event.Lowerpitch);
            gemSpawn.velocity = 0.1f;
            other.gameObject.SetActive(false);
        }
    }
}
