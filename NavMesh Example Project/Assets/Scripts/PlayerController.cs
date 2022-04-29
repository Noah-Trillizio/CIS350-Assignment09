/*
 * (Noah Trillizio)
 * (Assignment 09)
 * (Controls the movment of the Player)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter charcater;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        charcater = GetComponent<ThirdPersonCharacter>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            charcater.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            charcater.Move(Vector3.zero, false, false);
        }
    }
}
