using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBowScript : MonoBehaviour
{
    private Rigidbody _myBody;
    public float speed = 30f;
    public float DeactiveTimer = 3f;
    public float Damage = 15f;
    // Start is called before the first frame update
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Invoke("DeactiveGameObejct", DeactiveTimer);
    }
    public void Launch(Camera camera)
    {
        _myBody.velocity=camera.transform.forward*speed;
        transform.LookAt(transform.position+_myBody.velocity);
    }
   void DeactiveGameObejct()
    {
        if(gameObject.activeInHierarchy)
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==Tags.ENEMY_TAG)
        {
            other.GetComponent<HealthScript>().ApplyDamage(Damage);
        }
    }
}
