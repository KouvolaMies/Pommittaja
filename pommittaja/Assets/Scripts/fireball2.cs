using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball2 : MonoBehaviour
{
    private Rigidbody2D rb;
    void Awake()
    {
        player2 p2 = FindAnyObjectByType<player2>();
        rb = GetComponent<Rigidbody2D>();
        bomb2 bmb = FindAnyObjectByType<bomb2>();
        if(bmb.ballnum2 <= 0){
            rb.velocity = new Vector2(6, 0);
        }
        if(bmb.ballnum2 > 0 && bmb.ballnum2 < 2){
            rb.velocity = new Vector2(-6, 0);
        }
        if(bmb.ballnum2 > 1 && bmb.ballnum2 < 3){
            rb.velocity = new Vector2(0, 6);
        }
        if(bmb.ballnum2 > 2 && bmb.ballnum2 < 4){
            rb.velocity = new Vector2(0, -6);
        }
        Invoke("lifetime", p2.flife2);
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
