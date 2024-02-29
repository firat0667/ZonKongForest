using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator _enemyAnim;
    private NavMeshAgent _agent;
    private EnemyController _enemyController;

    public float Health = 100;
    public bool IsPlayer, IsBoar, IsCannibal;
    private bool _isDead;

    private PlayerStats _playerStats;


    private void Awake()
    {
        if(IsBoar || IsCannibal)  
        {
            _enemyAnim = GetComponent<EnemyAnimator>();
            _agent = GetComponentInChildren<NavMeshAgent>();
            _enemyController = GetComponent<EnemyController>();
        }
        if (IsPlayer)
        {
            _playerStats = GetComponent<PlayerStats>();
        }
    }
    public void ApplyDamage(float damage)
    {
        if (_isDead)
            return;

        Health-= damage;
        if (IsPlayer)
        {
            // show the stats
        }
        if (IsBoar || IsCannibal)
        {
            if (_enemyController.EnemyStates == EnemyState.PATROL)
            {
                _enemyController.ChaseDistance = 50f;
            }
            
        }
        if (Health <= 0)
        {
            Died();
            _isDead = true;
        }
        
    }

    private void Died()
    {
        if (IsCannibal)
        {
            GetComponentInChildren<Animator>().enabled = false;
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.up * 1f);

            _enemyController.enabled = false;
            _agent.enabled = false;
            _enemyAnim.enabled = false;
            // spawn cannibal
            int random = UnityEngine.Random.Range(0, 3);
            GetComponent<EnemySound>().Hits[random].enabled=true;
            MoneyManager.Instance.AddMoney(50);
            EnemyManager.Instance.EnemyDied(true);
        }
        if(IsBoar){
            _agent.velocity = Vector3.zero;
            _agent.isStopped = true;
            _enemyController.enabled=false;
            _enemyAnim.Dead();
            int random = UnityEngine.Random.Range(0, 3);
            GetComponent<EnemySound>().Hits[random].enabled = true;
            MoneyManager.Instance.AddMoney(50);
            EnemyManager.Instance.EnemyDied(false);
        }
        if (IsPlayer)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for (int i = 0; i < enemies.Length; i++)
            {
                if(enemies[i].GetComponent<EnemyController>()!=null)
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }
            // stop spawn enemies
            EnemyManager.Instance.StopSpawning();
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }
        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);

        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayer && Health<100)
            Health += 1 * Time.deltaTime;
    }
}
