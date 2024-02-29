using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float Damage = 2f;
    public float Radius = 1f;
    public LayerMask layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, Radius, layerMask);
        if (hits.Length > 0 )
        {
            print("We touched" + hits[0].gameObject.tag);
            hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(Damage);
            gameObject.SetActive(false);
            hits[0] = null;
           
        }
    }
}
