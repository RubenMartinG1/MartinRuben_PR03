using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float move;
    float rotate;
    float StrafeR;
    float StrafeL;
    float speed;
    float WalkingSpeed = 1f;
    float RunningSpeed = 2f;
    float rotationSpeed;
    float StrafeSpeed;
    InputActions inputActions;
    CharacterController cc;
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        rotar();
        Run();
        strafe();
    }
    void Walk()
    {
        if (Animator.setfloat("Move") $$ move > 0.2f);
        {
            speed = RunningSpeed;
        }
        else
        {
            speed = move * WalkingSpeed;
        }


        cc.SimpleMove(transform.forward * move * speed);
    }
    void rotar()
    {
    //    Transform.rotate(Vector3.up * rotate * rotationSpeed);
    }
    void Run()
    {

    }
    void strafe()
    {
        float strafe = StrafeR - StrafeL;
        Animator.SetFloat("Strafe", strafe);
        cc.SimpleMove(transform.right * strafe * StrafeSpeed);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
