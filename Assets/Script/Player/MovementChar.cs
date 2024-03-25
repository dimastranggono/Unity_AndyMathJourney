using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class MovementChar : MonoBehaviour
{
    public Healthbar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    private Rigidbody2D rb;
    private Animator anime;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public GameObject panelAlert;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 1.8f;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0){
            rb.AddForce(Vector2.up * 320f);
        }

        if(Mathf.Abs(dirX) > 0 && rb.velocity.y == 0){
            anime.SetBool("isRunning", true);
        }else{
            anime.SetBool("isRunning", false);
        }

        if(rb.velocity.y > 0){
            anime.SetBool("isJumping", true);
        }
        if(rb.velocity.y < 0){
            anime.SetBool("isJumping", false);
        }

        // if(currentHealth <= 0){
        //     SceneManager.LoadScene("quizretry");
        // }


        if(currentHealth <= 0){
            panelAlert.transform.GetChild(7).gameObject.SetActive(true);
            
        }
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(dirX,rb.velocity.y);
    }

    private void LateUpdate (){
        if(dirX>0){
            facingRight = true;
        }else if(dirX<0){
            facingRight = false;
        }
        if(((facingRight) && (localScale.x<0)) || ((!facingRight) && (localScale.x > 0))){
            localScale.x *= -1;
        }
         transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Deadly" ||col.gameObject.tag == "Enemy"){
            TakeDamage(20);
            anime.SetTrigger("isDead");
        }
    }

    void TakeDamage(int damage){
        currentHealth -= damage; 
        healthBar.setHealth(currentHealth);

    }
     void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Deadly" ||coll.gameObject.tag == "Enemy"){
            TakeDamage(20);
            anime.SetTrigger("isDead");
        }
    }
}
