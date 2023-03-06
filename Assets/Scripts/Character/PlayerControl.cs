using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Need Get Compoenent
    Transform cameraObject;
    Rigidbody rb;
    Animator animator;

    // Move Parameter
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;

    private Vector3 moveDirection;

    [Header("Player Status")]
    [SerializeField] private bool idle;
    [SerializeField] private bool run;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float delta = Time.deltaTime;

        HandleRotation(delta);

        moveDirection = cameraObject.forward * InputManager.Instance.GetMoveVertical;
        moveDirection += cameraObject.right * InputManager.Instance.GetMoveHorizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = moveSpeed;
        moveDirection *= speed;

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rb.velocity = projectedVelocity;

        UpdatePlayerStatus();
        AmimatorControl();
    }

    #region Move
    Vector3 normalVector;
    Vector3 targetPosition;

    private void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = cameraObject.forward * InputManager.Instance.GetMoveVertical;
        targetDir += cameraObject.right * InputManager.Instance.GetMoveHorizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
            targetDir = transform.forward;

        float rs = rotateSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, rs * delta);

        transform.rotation = targetRotation;
    }
    #endregion

    #region AmimatorControl
    private void UpdatePlayerStatus()
    {
        if (InputManager.Instance.GetMoveInput != Vector3.zero)
        {
            idle = false;
            run = true;
        }
        else
        {
            idle = true;
            run = false;
        }
    }
    
    private void AmimatorControl()
    {
        if (run)
            animator.SetBool("isRun", true);
        else
            animator.SetBool("isRun", false);
    }
    #endregion
}
