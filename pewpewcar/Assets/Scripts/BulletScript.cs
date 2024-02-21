using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //if bullet hits somthing with teh "target" tag prints "hit" and destroyes bullet
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Target")){
            print("hit" + collision.gameObject.name + " !");
            Destroy(gameObject);
        }
    }
}
