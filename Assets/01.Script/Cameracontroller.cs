using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Transform cameraTransTransform;
    public Transform targetTransform;
    private Transform cameraTransform;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;

    public float detailX = 40f;
    public float detailY = 40f;
    public float rotateX;
    public float rotateY;
    public float targetOffset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        rotateX += mouseX * detailX*Time.deltaTime;
        rotateY+=mouseY * detailY*Time.deltaTime;

        transform.eulerAngles = new Vector3(0, rotateX, 0);
        targetTransform.eulerAngles =new Vector3(0,rotateX,0);

        transform.position = cameraTransTransform.position -transform.forward*distance+Vector3.up*height;

        cameraTransform.LookAt(cameraTransTransform);
    }

}
