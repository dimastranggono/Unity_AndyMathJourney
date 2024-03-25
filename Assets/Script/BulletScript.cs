using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    MovementChar target;
    Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<MovementChar>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject,1200f);
    }

    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name.Equals("MovementChar")){
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

}
