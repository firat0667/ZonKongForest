using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPoint : MonoBehaviour
{
    public GameObject AttackPoint;
    void TurnOnAttackP�int()
    {
        AttackPoint.SetActive(true);
    }
    void TurnOffAttackP�int()
    {
        if (AttackPoint.activeInHierarchy)
            AttackPoint.SetActive(false);
    }
}
