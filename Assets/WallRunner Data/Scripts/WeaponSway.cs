using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] float swayAmount;
    [SerializeField] float smooth;
    Quaternion targetRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayAmount;
        float mouseX = Input.GetAxisRaw("Mouse X") * swayAmount;
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, transform.up);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, transform.right);

        float horizontal = Input.GetAxis("Horizontal") * swayAmount;
        if (Mathf.Abs(horizontal) > 0){
            Quaternion rotationZ = Quaternion.AngleAxis(horizontal, transform.forward);
            targetRotation = rotationX * rotationY * rotationZ;
        }
         else targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

    }
}
