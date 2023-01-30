using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    int actualState;
    [SerializeField] Transform[] puntosPatrullas;
    bool detectado = false;
    NavMeshAgent navMesh;
    float goalDistance;
    Vector3 goal;
    Animator animator;
    float speed;
    [SerializeField] Transform padrePatrulla;
   
   
    Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        actualState = 0;
        Invoke("Patrulla", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        print(actualState);
        Distance();
        animator.SetInteger("State", actualState);
        Speed();
        UpdateState();
        Detect();
        



        if (actualState == 2)
        {
            chase();
        }
    }

    void Patrulla()
    {
        if (!detectado)
        {
           
            actualState = 1;
         
            
            int n = Random.Range(0, puntosPatrullas.Length);

            navMesh.SetDestination(puntosPatrullas[n].position);

            goal = puntosPatrullas[n].position;
        }
    }

    void Distance()
    {
        goalDistance = Vector3.Distance(transform.position, goal);
    }
    void Speed()
    {
        if (actualState == 1)
        {
            speed = 1f;
        }
        else if (actualState == 2)

        {
            speed = 2f;
        }
        else
        {
            speed = 0f;
        }
        navMesh.speed = speed;

    }
  
    void UpdateState()
    {
        if (actualState == 1 && goalDistance < 1f)
        {
            
            actualState = 0;
            float pausa = Random.Range(2f, 6f);
            Invoke("Patrulla", pausa);
        }
        else if ((actualState == 0 || actualState == 1) && detectado == true)
        {
            actualState = 2;
        }
        else if((actualState == 2 && goalDistance < 1f))
        {
            actualState = 3;

        }
        if ((actualState == 3 && goalDistance > 1.5f))
        {
            actualState = 2;
        }

        if ((actualState == 2 && goalDistance > 15f))

        {
            actualState = 1;
         
            int n = Random.Range(0, puntosPatrullas.Length);
            goal = puntosPatrullas[n].position;
            navMesh.SetDestination(puntosPatrullas[n].position);
        }

      

    }
    void Detect()
    {
        float playerDist = Vector3.Distance(transform.position, playerPos.position);
        if (playerDist < 15f) 
        {
            goal = playerPos.position;
            detectado = true;
        }
        else
        {
            detectado = false;
        }
    }
    void chase()
    {
        navMesh.SetDestination(playerPos.position);
       
    }
    
}


