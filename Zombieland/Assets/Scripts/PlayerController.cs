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
    float WalkingSpeed = 2f;
    float RunningSpeed = 40f;
    float rotationSpeed = 1f;
    float StrafeSpeed = 20f;
    float running;
    float strafe;
  




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

        inputActions.Player.Run.performed += ctx => running = ctx.ReadValue<float>();
        inputActions.Player.Run.canceled += _ => running = 0f;

        inputActions.Player.StrafeL.performed += ctx => StrafeL = ctx.ReadValue<float>();
        inputActions.Player.StrafeL.canceled += _ => StrafeL = 0f;

        inputActions.Player.StrafeR.performed += ctx => StrafeR = ctx.ReadValue<float>();
        inputActions.Player.StrafeR.canceled += _ => StrafeR = 0f;

        inputActions.Player.Rotate.performed += ctx => rotate = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += _ => rotate = 0f;



    }
    void Start()
    {
        
    }

    // Update is called once per frame
 
    void Walk()
    {
        if (anim.GetBool("Run") && move > 0.2)
        {
          
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
        //Transform.Rotate(Vector3.up * rotate * rotationSpeed);
    }
    void Run()
    {
    if (running > 0.1)
    {
         
        anim.SetBool("Run", true);
        speed = RunningSpeed;
    }
    else
    {
        
        anim.SetBool("Run", false);
        speed = WalkingSpeed;
    }
    cc.SimpleMove(transform.forward * move * speed);
}
    void Strafe()
    {
        strafe = StrafeR - StrafeL;
        anim.SetFloat("Strafe", strafe);
        cc.SimpleMove(transform.right * strafe * StrafeSpeed);
    }

    void Update()
    {
        

        if (strafe == 0)
        {
            print("hola");
            Walk();
        }
        if (strafe != 1)
        {
            
            Strafe();
        }
        rotar();
        Run();
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
