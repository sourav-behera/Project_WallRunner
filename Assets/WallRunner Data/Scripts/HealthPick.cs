using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPick : MonoBehaviour
{
    float rotspeed = 50f;

    public static HealthPick healthPick;
    public bool canPickHealth = true;
    private void Start() {
        if (healthPick == null) {
            healthPick = this;
        }
    }
    private void Update()
    {   
        transform.Rotate(Vector3.up * rotspeed * Time.deltaTime);
        // if (canPickHealth){
        //     this.gameObject.GetComponent<SphereCollider>().enabled = true;
        // }else{
        //     this.gameObject.GetComponent<SphereCollider>().enabled = false;
        // }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerHel>().currentHealth < 100f)
            {
                collision.gameObject.GetComponent<PlayerHel>().currentHealth = 100f;
                Destroy(this.gameObject);
            }
            
        }
    }
}
