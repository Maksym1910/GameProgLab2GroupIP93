using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - cameraTarget.position;
    }

    void LateUpdate()
    {
        offset = Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X"), 0)) * offset;
        transform.position = cameraTarget.position + offset;
        transform.LookAt(cameraTarget);
    }
}
