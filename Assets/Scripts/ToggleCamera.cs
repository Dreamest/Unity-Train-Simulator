using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCamera : MonoBehaviour
{
    public Toggle side;
    public GameObject sideCamera;
    public Toggle front;
    public GameObject frontCameraA, frontCameraB;
    public GameObject train;
    private Animator trainAnimator;
    // Start is called before the first frame update


    void Start()
    {
        trainAnimator = train.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(side.isOn)
        {
            sideCamera.SetActive(true);
            frontCameraA.SetActive(false);
            frontCameraB.SetActive(false);
        }
        else if(front.isOn)
        {
            if(trainAnimator.GetCurrentAnimatorStateInfo(0).IsName("A to B") || trainAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle A"))
            {
            sideCamera.SetActive(false);
            frontCameraA.SetActive(false);
            frontCameraB.SetActive(true);
            }
            else if(trainAnimator.GetCurrentAnimatorStateInfo(0).IsName("B to A") || trainAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle B"))
            {
            sideCamera.SetActive(false);
            frontCameraA.SetActive(true);
            frontCameraB.SetActive(false);
            }
        }
    }
    
    
}
