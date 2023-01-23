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
    float WalkingSpeed = 20f;
    float RunningSpeed = 40f;
    float rotationSpeed;
    float StrafeSpeed = 20f;
  
    InputActions inputActions;
    CharacterController cc;
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        inputActions = new InputActions();
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<float>();
        inputActions.Player.Move.canceled += _ => move = 0f;

        inputActions.Player.Run.performed += _ => anim.GetBool("Run");
        inputActions.Player.Run.canceled += _ => anim.GetBool("Run");

        inputActions.Player.StrafeL.performed += ctx => StrafeL = ctx.ReadValue<float>();
        inputActions.Player.StrafeL.canceled += _ => StrafeL = 0f;

        inputActions.Player.StrafeR.performed += ctx => StrafeR = ctx.ReadValue<float>();
        inputActions.Player.StrafeR.canceled += _ => StrafeR = 0f;


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
        if (anim.GetBool("Run") && move > 0.2)
        {
            print(move);
            speed = RunningSpeed;
        }
        else
        {
            speed = WalkingSpeed;
            
        }


        cc.SimpleMove(transform.forward * move * speed);
        anim.SetFloat("Move", move);
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
        anim.SetFloat("Strafe", strafe);
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
