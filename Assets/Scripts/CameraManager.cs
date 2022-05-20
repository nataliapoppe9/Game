using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    [SerializeField] Camera cameraView;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.enabled = false;
        cameraView.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
