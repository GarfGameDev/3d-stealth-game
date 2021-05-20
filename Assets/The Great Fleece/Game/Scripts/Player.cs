using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Camera camera;
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;

    void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0) == true) 
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) 
            {
                
                Debug.Log(hit.point);

                _agent.SetDestination(hit.point);
                _anim.SetBool("Walk", true);
                _target = hit.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        if (distance < 1)
        {
            _anim.SetBool("Walk", false);
        }
    }

}
