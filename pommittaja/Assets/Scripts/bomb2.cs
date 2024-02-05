using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb2 : MonoBehaviour
{
    public int ballnum2 = 0;
    [SerializeField] private Transform firespawn;
    [SerializeField] private Rigidbody2D fireprefab;

    private void Awake(){
        Invoke("Explosion", 2);
    }

    private void Explosion(){
        for(ballnum2 = 0; ballnum2 < 4; ballnum2++){
            Rigidbody2D fireball2 = Instantiate(fireprefab, firespawn.position, Quaternion.identity);
        }
        player2 p2 = FindAnyObjectByType<player2>();
        p2.bombnum2--;
        ballnum2 = 0;
        Destroy(gameObject);
    }
}