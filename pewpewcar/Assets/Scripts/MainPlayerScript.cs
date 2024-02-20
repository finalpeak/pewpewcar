using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{

    public int damage;
    public Vector3 carCoords3d;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");

        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb != null){
            //rb.useGravity = true;
            rb.AddForce(Vector3.up * 1000f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Damage: " + damage);
    }
}
