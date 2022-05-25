using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    //velocidad desplaz cam y vel angular
    public float speed, speedAng;
    //objeto de camara virtual
    public CinemachineVirtualCamera vcam;
    
    // Start is called before the first frame update
    void Start()
    {
        //cojo el componente camara de
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputWASD = new Vector3(
            Input.GetAxis("RotCamH"),0,
            Input.GetAxis("RotCamV"));

        Vector3 inputFLECHA = new Vector3(
            Input.GetAxis("Horizontal"),0,
            Input.GetAxis("Vertical"));

        Vector3 movDir = (transform.forward * inputFLECHA.z) + (transform.right * inputFLECHA.x) + (transform.up * inputFLECHA.y);

        transform.position += movDir.normalized * speed * Time.deltaTime;

        transform.Rotate(inputWASD.z*speedAng, speedAng*inputWASD.x, 0);

        
        vcam.m_Lens.FieldOfView += Input.GetAxis("Mouse Y");
        vcam.m_Lens.FieldOfView= Mathf.Clamp(vcam.m_Lens.FieldOfView, 30, 90);
    }

    
}
