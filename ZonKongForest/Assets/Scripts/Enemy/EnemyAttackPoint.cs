using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPoint : MonoBehaviour
{
    public GameObject AttackPoint;
    void TurnOnAttackPýint()
    {
        AttackPoint.SetActive(true);
    }
    void TurnOffAttackPýint()
    {
        if (AttackPoint.activeInHierarchy)
            AttackPoint.SetActive(false);
    }
}
