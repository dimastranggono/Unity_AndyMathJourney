using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy"){
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            Die();
        }
    }
}
