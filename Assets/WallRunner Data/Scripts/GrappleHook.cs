using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    [SerializeField] float hookForce =20f;
    [SerializeField] float hookForceMultiplier = 10f;
    [SerializeField] float maxDistance = 20f;
    [SerializeField] Transform muzzle;
    [SerializeField] Transform gun;
    Vector3 target;
    public bool isGrappling;
    public bool canGrapple;
    bool reset;
    float distance;
    public LayerMask whatIsGrapable;

    public static GrappleHook grappleHook;
    [SerializeField]LineRenderer lr;
    float timer=0f;
    [SerializeField] float grappleTime = 1f;



    void Start()
    {
        if (grappleHook == null) grappleHook = this;
    }

    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.R)){
            canGrapple = false;
        }else canGrapple = true;
        if (canGrapple ){
            if (reset){
                
                if (Input.GetKey(KeyCode.Mouse1)){
                    gun.gameObject.SetActive(true);
                    Grapple();
                    reset = false;
                    timer += Time.deltaTime;
                }
                

            }
            if (Input.GetKeyUp(KeyCode.Mouse1)){
                canGrapple = false;
                isGrappling = false;
                reset = true;
                timer = 0f;
            }

        }
    }
    void LateUpdate() {
        DrawRope();
    }
    void Grapple (){
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, whatIsGrapable)){

            target = hit.point;
            Vector3 direction = (target - player.transform.position).normalized;
            distance = Vector3.Distance(target , player.transform.position);
            StartCoroutine(Move(direction));

        } 
    }
    IEnumerator Move(Vector3 direction){
        while (player.transform.position != target){
            isGrappling = true;
            timer += Time.deltaTime;
            if (!canGrapple) break;
            if (Vector3.Distance(player.transform.position, target) <= 0.1f) break;
            if (timer >= grappleTime) break;
            player.GetComponent<Rigidbody>().AddForce(direction*hookForce*hookForceMultiplier*Time.deltaTime, ForceMode.Force);
            yield return null;

            
        }
        timer = 0f;
        gun.gameObject.SetActive(false);
        isGrappling = false;
    }

    void DrawRope(){
        if (!isGrappling){
            lr.positionCount = 0;
        }else {
            lr.positionCount = 2;
            lr.SetPosition(1, target);
            lr.SetPosition(0, muzzle.transform.position);
        }
    }
    void DontDrawRope(){
        lr.positionCount = 0; 
    }
}
