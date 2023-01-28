using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    Animator cameraAnimator;

    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
    }

    public void MoveToLevel()
    {
        cameraAnimator.SetTrigger("ToLevel");
    }

    public void MoveToMenu()
    {
        cameraAnimator.SetTrigger("ToMenu");
    }
}
