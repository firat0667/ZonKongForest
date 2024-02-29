using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Walk(bool walk)
    {
        _animator.SetBool(AnimationTags.WALK_ANIM, walk);
    }
    public void Run(bool run)
    {
        _animator.SetBool(AnimationTags.RUN_ANIM, run);
    }
    public void Attack()
    {
        _animator.SetTrigger(AnimationTags.ATTACK_ANIM);
    }
    public void Dead()
    {
        _animator.SetTrigger(AnimationTags.DEAD_ANIM);
    }
}
