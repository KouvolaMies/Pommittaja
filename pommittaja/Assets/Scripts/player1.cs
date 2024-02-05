using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private bool moving;
    public int bombnum = 0;
    public int maxbombs = 1;
    private int ptimer = 0;
    public float flife = 0.3f;
    [SerializeField] private Transform bombspawn;
    [SerializeField] private Rigidbody2D bombprefab;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        bombnum = 0;
        maxbombs = 1;
    }

    void Update(){
        movement();
        if(Input.GetKeyDown("space")){
            Bombspawn();
        }
    }

    void movement(){
        if(Input.GetKey("w")){
            rb.velocity = new Vector2(rb.velocity.x, 3);
            bombspawn.position = new Vector2(transform.position.x, (transform.position.y + 0.8f));
        }
        if(Input.GetKey("s")){
            rb.velocity = new Vector2(rb.velocity.x, -3);
            bombspawn.position = new Vector2(transform.position.x, (transform.position.y + -0.8f));
        }
        if(Input.GetKey("d")){
            rb.velocity = new Vector2(3, rb.velocity.y);
            bombspawn.position = new Vector2((transform.position.x + 0.8f), transform.position.y);
        }
        if(Input.GetKey("a")){
            rb.velocity = new Vector2(-3, rb.velocity.y);
            bombspawn.position = new Vector2((transform.position.x + -0.8f), transform.position.y);
        }
        if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a")){
            moving = true;
        }
        else{
            moving = false;
        }
        if(moving == false){
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Bombspawn(){
        //spawns bombs
        if(bombnum < maxbombs){
            Rigidbody2D bomb = Instantiate(bombprefab, bombspawn.position, Quaternion.identity);
            bombnum++;
        }
        //powerup usage limit
        if(maxbombs > 1 || flife > 0.3f){
            ptimer++;
        }
        if(ptimer > 5){
            maxbombs = 1;
            flife = 0.3f;
            ptimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        //explosion collision check
        if(collision.CompareTag("boom")){
            gameManager gm = FindAnyObjectByType<gameManager>();
            gm.gameOver();
            Destroy(gameObject);
        }
        //more bombs poweup check
        if(collision.CompareTag("morebombs")){
            mbdestroy mb = FindAnyObjectByType<mbdestroy>();
            mb.mbDestroy();
            maxbombs = 2;
        }
        //bomb range powerup check
        if(collision.CompareTag("bombrange")){
            brdestroy br = FindAnyObjectByType<brdestroy>();
            br.brDestroy();
            flife = 0.5f;
        }
    }
}