using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private bool moving;
    public int bombnum2 = 0;
    public int maxbombs2 = 1;
    private int ptimer = 0;
    public float flife2 = 0.3f;
    [SerializeField] private Transform bombspawn2;
    [SerializeField] private Rigidbody2D bombprefab2;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        bombnum2 = 0;
        maxbombs2 = 1;
    }

    void Update(){
        movement();
        if(Input.GetKeyDown("n")){
            Bombspawn();
        }
    }

    void movement(){
        if(Input.GetKey("i")){
            rb.velocity = new Vector2(rb.velocity.x, 3);
            bombspawn2.position = new Vector2(transform.position.x, (transform.position.y + 0.8f));
        }
        if(Input.GetKey("k")){
            rb.velocity = new Vector2(rb.velocity.x, -3);
            bombspawn2.position = new Vector2(transform.position.x, (transform.position.y + -0.8f));
        }
        if(Input.GetKey("l")){
            rb.velocity = new Vector2(3, rb.velocity.y);
            bombspawn2.position = new Vector2((transform.position.x + 0.8f), transform.position.y);
        }
        if(Input.GetKey("j")){
            rb.velocity = new Vector2(-3, rb.velocity.y);
            bombspawn2.position = new Vector2((transform.position.x + -0.8f), transform.position.y);
        }
        if(Input.GetKey("i") || Input.GetKey("k") || Input.GetKey("l") || Input.GetKey("j")){
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
        if(bombnum2 < maxbombs2){
            Rigidbody2D bomb2 = Instantiate(bombprefab2, bombspawn2.position, Quaternion.identity);
            bombnum2++;
        }
        //powerup usage limit
        if(maxbombs2 > 1 || flife2 > 0.3f){
            ptimer++;
        }
        if(ptimer > 5){
            maxbombs2 = 1;
            flife2 = 0.3f;
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
            maxbombs2 = 2;
        }
        //bomb range powerup check
        if(collision.CompareTag("bombrange")){
            brdestroy br = FindAnyObjectByType<brdestroy>();
            br.brDestroy();
            flife2 = 0.5f;
        }
    }
}