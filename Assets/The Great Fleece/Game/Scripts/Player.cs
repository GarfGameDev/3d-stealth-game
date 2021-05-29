using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Camera camera;
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;    
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;

    private bool _coinThrown = false;


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


        if (Input.GetMouseButtonDown(1) && _coinThrown == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _anim.SetTrigger("Throw");
                _coinThrown = true;
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, hitInfo.point);
                SendAIToCoin(hitInfo.point);
            }
        }
    }

    void SendAIToCoin(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator guardAnim = guard.GetComponent<Animator>();

            currentGuard.coinThrown = true;
            currentAgent.SetDestination(coinPos);
            guardAnim.SetBool("Walking", true);
            currentGuard.coinPos = coinPos;

        }
    }

}
