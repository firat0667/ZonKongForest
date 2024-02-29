using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyManager Instance;
   [SerializeField] private GameObject _boarPref, _cannibalPref;
    public Transform[] CanninalSpawnPos, BoarSpawnPos;
    [SerializeField] private int _cannibalEnemyCount, _boarEnemyCount;
    private int _initialCannibalCount, _initialBoarCount;
    public float WaitBeforeSpawnEnemies = 10f;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        _initialCannibalCount = _cannibalEnemyCount;
        _initialBoarCount = _boarEnemyCount;
        SpawnEnemies();
        StartCoroutine("ICheckToSpawnEnemies");
    }

    void SpawnEnemies()
    {
        SpawnBoar();
        SpawnCannibal();
    }
      void SpawnCannibal()
    {
        int index = 0;
        if (index >= CanninalSpawnPos.Length)
            index = 0;
        for (int i = 0; i < _cannibalEnemyCount; i++)
        {
            Instantiate(_cannibalPref, CanninalSpawnPos[index].position, Quaternion.identity);
            index++;
        }
        _cannibalEnemyCount = 0;
    }
   void SpawnBoar()
    {
        int index = 0;
        if (index >= BoarSpawnPos.Length)
            index = 0;
        for (int i = 0; i < _boarEnemyCount; i++)
        {
            Instantiate(_boarPref, BoarSpawnPos[index].position, Quaternion.identity);
            index++;
        }
        _boarEnemyCount = 0;
    }

   public void EnemyDied(bool cannibal)
    {
        if (cannibal)
        {
            _cannibalEnemyCount++;
            if(_cannibalEnemyCount>_initialCannibalCount)
            {
                _cannibalEnemyCount = _initialCannibalCount;
            }
        }
        else
        {
            _boarEnemyCount++;
            if(_boarEnemyCount>_initialBoarCount)
            {
                _boarEnemyCount= _initialBoarCount;
            }

        }
    }
    IEnumerator ICheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(WaitBeforeSpawnEnemies);
        SpawnBoar();
        SpawnCannibal();
        StartCoroutine("ICheckToSpawnEnemies");
    }
    public void StopSpawning()
    {
        StopCoroutine("ICheckToSpawnEnemies");
    }
}
