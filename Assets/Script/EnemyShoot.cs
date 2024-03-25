using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    float firerate;
    float nextfire;
    // Start is called before the first frame update
    void Start()
    {
        firerate = 8f;
        nextfire = Time.time;
    }

    void Update()
    {
        // OnTriggerEnter2D();
         CheckIfTimeFire();
    }

    void CheckIfTimeFire(){
        if(Time.time > nextfire){
            Instantiate (bullet, transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    } 
    // void OnTriggerEnter2D(Collider2D col){
    //     if(col.gameObject.tag == "Player"){
    //         CheckIfTimeFire();
    //     }
    // }

}
