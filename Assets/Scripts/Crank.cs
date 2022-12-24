using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crank : InteractableObject
{
    [SerializeField]
    SafeBox safeBox;
    [SerializeField]
    KeyPad keyPad;
    [SerializeField]
    Animator animator;
    public bool IsOpen = false;
    //bool holding = false;
    //Transform player;
    //Vector3 originalHit;
    //Vector2 turn;

    //[SerializeField]
    //Transform _camera;
    public override void Interact(Transform player, RaycastHit hit)
    {
        if (keyPad.IsOpen)
        {
            var animation = animator.runtimeAnimatorController.animationClips.First(a => a.name == "CrankOpen");
            animator.Play("CrankOpen");
            IsOpen = true;
        }
        //holding = !holding;
        //this.player = player;
        //originalHit = hit.point - transform.position;
        //Debug.Log(transform.position);
        //originalHit.Normalize();
        //Debug.DrawRay(transform.position, originalHit, Color.green, 100f);
    }

    void Update()
    {
        //if (!holding) return;
        //turn.x += Input.GetAxis("Mouse X");
        //turn.y += Input.GetAxis("Mouse Y");
        //transform.localRotation = Quaternion.Euler(-turn.y - turn.x, 0, 0);
        //var cameraHit = Vector3.ProjectOnPlane(_camera.forward - transform.position, originalHit);
        //var angleDifference = Vector3.Angle(originalHit, cameraHit);
        //transform.localRotation = Quaternion.Euler(angleDifference, 0, 0);
    }
}

