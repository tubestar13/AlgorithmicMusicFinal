using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State { idle, walking, jumping, falling }
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;

    private int count;

    public Text countText;

    // Instantiate the heavy plugin library
    private Hv_final_AudioLib pd;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        ground = LayerMask.GetMask("Ground");

        pd = GetComponent<Hv_final_AudioLib>();

        //start the noise
        pd.SendEvent(Hv_final_AudioLib.Event.Startstop);

    }


    private void FixedUpdate()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");


        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }

        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        VelocityState();
        anim.SetInteger("state", (int)state);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jumping;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            pd.SendEvent(Hv_final_AudioLib.Event.Stinger);
            float selectSeq = Random.Range(0, 3);
            if (selectSeq < 1)
                pd.SetFloatParameter(Hv_final_AudioLib.Parameter.Selectseq, 1);
            else if (selectSeq < 2)
                pd.SetFloatParameter(Hv_final_AudioLib.Parameter.Selectseq, 2);
            else if (selectSeq < 3)
                pd.SetFloatParameter(Hv_final_AudioLib.Parameter.Selectseq, 3);
        }
        
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.walking;

        }
        else
        {
            state = State.idle;
        }
    }
}
