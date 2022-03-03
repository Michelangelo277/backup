using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deechar : MonoBehaviour
{

    public float MoveSpd;
    public float JumpFrc = 1;
    public int healthVal = 100;
    public float timer = 60;
    private Rigidbody2D _rigidbody;

    //for Respawning when falling into pits
    private Vector3 rspwnPnt;
    public GameObject pitDetc;

    //for sprinting
    public bool runChek = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        rspwnPnt = transform.position;
    }

    private void Update()
    {

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpd;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001)
        {
            _rigidbody.AddForce(new Vector2(0, JumpFrc), ForceMode2D.Impulse);
        }

        pitDetc.transform.position = new Vector2(transform.position.x, pitDetc.transform.position.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runChek = true;
        }
        else {
            runChek = false;
        }

        if (runChek == true)
        {
            MoveSpd = 15;
        }
        else {
            MoveSpd = 7;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "pit") {
            transform.position = rspwnPnt;
        }
        if (collision.tag == "hurtbox")
        {
            healthVal -= 20;

        }
        if (collision.tag == "burndmg")
        {
            healthVal -= 3;
        }

        if (healthVal <= 0)
        {
            transform.position = rspwnPnt;
            healthVal = 100;
        }


    }
}


