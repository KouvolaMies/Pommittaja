using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mbprefab;
    [SerializeField] private Rigidbody2D brprefab;
    private int pnum = 1;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("boom")){
            powerspawn();
            Destroy(gameObject);
        }
    }

    void powerspawn(){
        pnum = Random.Range(1, 100);
        if(pnum < 10){
            Rigidbody2D morebombs = Instantiate(mbprefab, transform.position, Quaternion.identity);
        }
        if(pnum > 90){
            Rigidbody2D bombrange = Instantiate(brprefab, transform.position, Quaternion.identity);
        }
    }
}