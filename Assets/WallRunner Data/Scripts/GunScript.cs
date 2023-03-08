using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Camera cam;
    public Transform muzzle;

    public float bulletForce = 50.0f;
    public float damage = 20.0f;

    GameObject tempBullet;

    public Image []muzzleFlashImage;
    public Sprite[] flashes;
    [SerializeField] float fireRate = 1;
    float timeSinceLastShot;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        muzzleFlashImage[0].color = new Color(0, 0, 0, 0);
        muzzleFlashImage[1].color = new Color(0, 0, 0, 0);

    }

    void Update()
    {
       if (!PauseMenuScript.pauseMenuScript.isPaused){
            timeSinceLastShot += Time.deltaTime;
            if (Input.GetKey(KeyCode.Mouse0))
            {   
                if (timeSinceLastShot >= fireRate){
                shoot();
                animator.SetBool("isFiring", true);
                muzzleFlash.Play();
                audioSource.Play();
                
                }
            }else animator.SetBool("isFiring", false);
       }
        
    }

    void shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 target;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }
        else
        {
            target = ray.GetPoint(75);
        }

        Vector3 bulletdirection = target - muzzle.position;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody>().AddForce(bulletdirection.normalized * bulletForce, ForceMode.Impulse);
        StartCoroutine(MuzzleFlash());
        timeSinceLastShot = 0;
    }

    IEnumerator MuzzleFlash()
    {   
        for (int i = 0; i<2; i++){
        muzzleFlashImage[i].sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashImage[i].color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashImage[i].sprite = null;
        muzzleFlashImage[i].color = new Color(0, 0, 0, 0);

        }
    }
    
}
