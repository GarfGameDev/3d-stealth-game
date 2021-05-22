using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;

    private int _currentTarget;
    private NavMeshAgent _agent;
    private bool _reverse = false;
    private bool _targetReached = false;

    private Animator _anim;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            

            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count -1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walking", false);
                }
                
            }
            else 
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walking", true);
                }
                
            }


            if (distance < 1.0f && _targetReached == false)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }
                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count - 1) && wayPoints.Count > 1)
                {
                    _targetReached = true;

                    StartCoroutine(WaitBeforeMoving());
                  
                }
                else 
                {

                        if (_reverse == true)
                        {
                            _currentTarget--;
                            if (_currentTarget <= 0)
                            {
                                _reverse = false;
                                _currentTarget = 0;
                            }
                        }
                        else 
                        {
                            _currentTarget++;
                        }  
                    

                }
                
                
            }


        }

    }

    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(2.0f);
        }

        else if (_currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);
        }

        else 
        {
            yield return null;
        }
        
        if (_reverse == true) 
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
            
        }
        else if (_reverse == false)
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
