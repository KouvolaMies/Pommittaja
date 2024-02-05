using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public int ballnum = 0;
    [SerializeField] private Transform firespawn;
    [SerializeField] private Rigidbody2D fireprefab;

    public void Awake(){
        Invoke("explosion", 2);
    }

    private void explosion(){
        for(ballnum = 0; ballnum < 4; ballnum++){
            Rigidbody2D fireball = Instantiate(fireprefab, firespawn.position, Quaternion.identity);
        }
        player1 p1 = FindAnyObjectByType<player1>();
        p1.bombnum--;
        ballnum = 0;
        Destroy(gameObject);
    }
}