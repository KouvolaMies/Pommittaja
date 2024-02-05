using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    void Awake()
    {
        player1 p1 = FindAnyObjectByType<player1>();
        rb = GetComponent<Rigidbody2D>();
        bomb bmb = FindAnyObjectByType<bomb>();
        if(bmb.ballnum <= 0){
            rb.velocity = new Vector2(6, 0);
        }
        if(bmb.ballnum > 0 && bmb.ballnum < 2){
            rb.velocity = new Vector2(-6, 0);
        }
        if(bmb.ballnum > 1 && bmb.ballnum < 3){
            rb.velocity = new Vector2(0, 6);
        }
        if(bmb.ballnum > 2 && bmb.ballnum < 4){
            rb.velocity = new Vector2(0, -6);
        }
        Invoke("lifetime", p1.flife);
    }

    void lifetime(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("wall")){
            Destroy(gameObject);
        }
    }
}