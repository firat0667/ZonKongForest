using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator _enemyAnim;
    private NavMeshAgent _navmeshAgent;
    private EnemyState _enemyState;

    public float WalkSpeed = .5f;
    public float RunSpeed = 4f;

    public float ChaseDistance = 7f;
    private float _currentChaseDistance;
    public float AttackDistance = 1.8f;
    public float ChaseAfterAttackDistance = 2f;

    public float PatrolRadiusMin=20f, PatrolRadiusMax=60f;
    public float PatrolForThisTime = 15f;

    private float _patrolTimer;

    public float WaitBeforeAttack = 2f;
    private float _attackTimer;

    private Transform _target;

    public bool IsBoar;
    private EnemySound _enemySound;
    public bool isGrounded;


    private void Awake()
    {
        _enemySound = GetComponent<EnemySound>();
        _enemyAnim = GetComponent<EnemyAnimator>();
        _navmeshAgent = GetComponentInChildren<NavMeshAgent>();
        _target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemyState=EnemyState.PATROL;
        _patrolTimer = PatrolForThisTime;
        _attackTimer = WaitBeforeAttack;
    }

    // Update is called once per frame
    void Update()
    {
            if (_enemyState == EnemyState.PATROL)
            {
                Patrol();
            }
            if (_enemyState == EnemyState.CHASE)
            {
                Chase();
            }
            if (_enemyState == EnemyState.ATTACK)
            {
                Attack();
            }   
    }
    private void Attack()
    {
        _navmeshAgent.velocity = Vector3.zero;
        _navmeshAgent.isStopped = true;

        _attackTimer += Time.deltaTime;

        if(_attackTimer>WaitBeforeAttack)
        {
            _enemyAnim.Attack();

            _attackTimer = 0;
        }

        if(Vector3.Distance(transform.position,_target.position) > AttackDistance+ChaseAfterAttackDistance)
        {

            _enemyState= EnemyState.CHASE;
        }
    }

    private void Chase()
    {
        if (IsBoar)
        {
            if (!_enemySound.Boar.enabled)
                _enemySound.Boar.enabled = true;
        }
        else
        {
            if (!_enemySound.Zonguldak.enabled)
                _enemySound.Zonguldak.enabled = true;
        }
           

        _navmeshAgent.isStopped = false;
        _navmeshAgent.speed = RunSpeed;

        _navmeshAgent.SetDestination(_target.position);
        if (_navmeshAgent.velocity.sqrMagnitude > 0)
        {
            _enemyAnim.Run(true);
        }
            
        else
            _enemyAnim.Run(false);

        if(Vector3.Distance(transform.position,_target.position) <= AttackDistance)
        {
            _enemyAnim.Run(false);
            _enemyAnim.Walk(false);
            _enemyState = EnemyState.ATTACK;

            if(ChaseDistance!=_currentChaseDistance)
            {
                ChaseDistance = _currentChaseDistance;

            }

        }
        else if(Vector3.Distance(transform.position,_target.position) > ChaseDistance)
        {
            _enemyAnim.Run(false);

            _enemyState= EnemyState.PATROL;

            _patrolTimer = PatrolForThisTime;

            if (ChaseDistance != _currentChaseDistance)
                ChaseDistance = _currentChaseDistance;
            
        }

    }

    private void Patrol()
    {
        //tell nav agent that he can move
        if(_navmeshAgent.isOnNavMesh)
        _navmeshAgent.isStopped = false;
        _navmeshAgent.speed = WalkSpeed;

        _patrolTimer += Time.deltaTime;

        if(_patrolTimer>PatrolForThisTime)
        {
            if (_navmeshAgent.isOnNavMesh)
                SetNewRandomDestination();
            _patrolTimer = 0;
        }
        if(_navmeshAgent.velocity.sqrMagnitude > 0)
        {
            if (IsBoar)
            {
                if (_enemySound.Boar.enabled)
                    _enemySound.Boar.enabled = false;
            }
            else
            {
                if (_enemySound.Zonguldak.enabled)
                    _enemySound.Zonguldak.enabled = false;
            }
            _enemyAnim.Walk(true);
        }
           
        
        else
            _enemyAnim.Walk(false);
        if (Vector3.Distance(transform.position,_target.position)<=ChaseDistance)
        {
            _enemyAnim.Walk(false);

            _enemyState = EnemyState.CHASE;
        }

    }

    private void SetNewRandomDestination()
    {
       float  randRadius=Random.Range(PatrolRadiusMin,PatrolRadiusMax);

        Vector3 randDir = Random.insideUnitSphere * randRadius;
        randDir += transform.position;

        NavMeshHit meshHit;

        NavMesh.SamplePosition(randDir, out meshHit, randRadius, -1);

        _navmeshAgent.SetDestination(meshHit.position);

    }
    public EnemyState EnemyStates
    {
        get; set;
    } 
 
}
