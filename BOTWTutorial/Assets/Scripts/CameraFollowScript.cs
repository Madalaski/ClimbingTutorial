using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 pivot;
    [SerializeField] Vector3 offset;

    Vector3 velo;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            Vector3 localRight = Vector3.Cross(Vector3.up, offset);
            offset =    Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up)
                        * Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), localRight)
                        * offset;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
                                                target.position + pivot + offset,
                                                ref velo,
                                                0.5f,
                                                20f,
                                                Time.fixedDeltaTime);
        transform.forward = target.position - transform.position;
    }
}
