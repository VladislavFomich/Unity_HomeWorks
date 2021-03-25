using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 0.2f;
    public float sprintSpeed = 5.0f;
    public float animationBlendSpeed = 0.2f;
    public float jumpSpeed = 7.0f;

    CharacterController controller;
    Animator animator;
    Camera characterCamera;
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0.0f;
    bool isSprint = false;

    float speedY = 0.0f;
    float gravity = -9.81f;
    bool isJamping = false;

    bool isDeath = false;

    int combo = 0;

   

    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }

    public Camera CharacterCamera
    {
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }

 
    // Update is called once per frame
    void Update()
    {
        CharacterAnimator.SetBool("StartSpawn", false);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire2") && !isDeath)
        {
            
            CharacterAnimator.SetTrigger("Death");
            isDeath = true;
            movementSpeed = 0;
            rotationSpeed = 0;
            sprintSpeed = 0;
            jumpSpeed = 0;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            int rnd = Random.Range(0, 5);
            CharacterAnimator.SetInteger("Combo", rnd);
           
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CharacterAnimator.SetInteger("Combo", 0);
        }

        if (Input.GetButtonDown("Jump") && !isJamping)
        {
            isJamping = true;
            CharacterAnimator.SetTrigger("Jump");
            speedY += jumpSpeed;
        }
        if (!Controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0.0f)
        {
            speedY = 0.0f;
        }
        CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
        if (isJamping && speedY < 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit,1f, LayerMask.GetMask("Default")))
            {
                isJamping = false;
                CharacterAnimator.SetTrigger("Land");
            }
        }

        isSprint = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
        Vector3 verticalMovement = Vector3.up * speedY;

        float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
        Controller.Move((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);

        if (rotatedMovement.sqrMagnitude > 0.0f)
        {
            rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0.0f;
        }
        CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
        Quaternion currentRotation = Controller.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
        Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
    }
}
