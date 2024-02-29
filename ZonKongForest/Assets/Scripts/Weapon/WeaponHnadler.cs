using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    None,
    Self_Aim,
    Aim
}
public enum WeaponFireType
{
    Single,
    Multiple
}
public enum WeaponBullet
{
    Bullet,
    Arrow,
    Spear,
    None
}
public class WeaponHandler : MonoBehaviour
{
    private Animator _animator;
    public WeaponAim WeaponAim;

   [SerializeField] private GameObject _muzzleFlash;
   [SerializeField] private AudioSource _shootSound, _reloadSound;

   public WeaponFireType FireType;
   public WeaponBullet BulletType;
   public GameObject AttackPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   public void ShootAnimation()
    {
        _animator.SetTrigger(AnimationTags.SHOOT_TRIGER);
    }
    public void Aim(bool canAim)
    {
        _animator.SetBool(AnimationTags.Aim_TRIGER, canAim);
    }
    void TurnOnMuzzleFlash()
    {
        _muzzleFlash.SetActive(true);
    }
    void TurnOffMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }
    void PlayShootSound()
    {
        _shootSound.Play();
    }
    void PlayReloadSound()
    {
        _reloadSound.Play();
    }
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
