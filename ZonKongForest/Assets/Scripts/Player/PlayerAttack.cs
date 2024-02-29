using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private WeaponManager _weaponManager;

    public float FireRate = 15f;
    public float Damage;
    private float _nextTimeToFire;
    private Animator _animatorZoomCamera;
    private bool _zoomed;
    private Camera _mainCamera;
    private GameObject _croshair;
    private bool _isAiming;
   [SerializeField] private GameObject _arrowPrefab, _spearPrefab,_bulletPrefab;
   [SerializeField] private Transform _arrowBowStartPosition;
   [SerializeField] private float _raycastHeight = .5f;
    private void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        _animatorZoomCamera=GameObject.FindGameObjectWithTag(Tags.FP_CAM).GetComponent<Animator>();
        _croshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        _mainCamera = Camera.main;
    }
  

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
    }
    void WeaponShoot()
    {
        if(_weaponManager.GetCurrentSelectedWeapon().FireType==WeaponFireType.Multiple)
        {
            if(Input.GetMouseButton(0)&& Time.time>_nextTimeToFire) 
            {
                _nextTimeToFire = Time.time+1f/FireRate;
                _weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(_weaponManager.GetCurrentSelectedWeapon().tag==Tags.AXE_TAG)
                    _weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                
                if (_weaponManager.GetCurrentSelectedWeapon().BulletType == WeaponBullet.Bullet)
                {
                    _weaponManager.GetCurrentSelectedWeapon() .ShootAnimation();
                     BulletFired();
                }
                else
                {
                    // we have a bow or spear
                    if (_isAiming)
                    {
                        _weaponManager.GetCurrentSelectedWeapon ().ShootAnimation();
                        if (_weaponManager.GetCurrentSelectedWeapon().BulletType == WeaponBullet.Arrow)
                        {
                            ThrowArrowOrSpear(true);
                        }
                        else if(_weaponManager.GetCurrentSelectedWeapon().BulletType == WeaponBullet.Spear)
                        {
                            ThrowArrowOrSpear(false);
                        }
                    }
                }
            }
        }
    }
    void ZoomInAndOut()
    {
        if (_weaponManager.GetCurrentSelectedWeapon().WeaponAim == WeaponAim.Aim)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _animatorZoomCamera.Play(AnimationTags.ZOOMIN_ANIM);
                _croshair.SetActive(false);
            }
            if (Input.GetMouseButtonUp(1))
            {
                _animatorZoomCamera.Play(AnimationTags.ZOOMOUT_ANIM);
                _croshair.SetActive(true);
            }
        }
        if(_weaponManager.GetCurrentSelectedWeapon().WeaponAim==WeaponAim.Self_Aim)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _weaponManager.GetCurrentSelectedWeapon().Aim(true);
                _isAiming = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                _weaponManager.GetCurrentSelectedWeapon().Aim(false);
                _isAiming = false;
            }

        }
    }
    void ThrowArrowOrSpear(bool throwArrow)
    {
        if (throwArrow)
        {
            GameObject arrow = Instantiate(_arrowPrefab);
            arrow.transform.position = _arrowBowStartPosition.position;
            arrow.GetComponent<ArrowAndBowScript>().Launch(_mainCamera);
        }
        else
        {
            GameObject spear = Instantiate(_spearPrefab);
            spear.transform.position = _arrowBowStartPosition.position;
            spear.GetComponent<ArrowAndBowScript>().Launch(_mainCamera);
        }
    }
    void BulletFired()
    {
        GameObject arrow = Instantiate(_bulletPrefab);
        arrow.transform.position = _arrowBowStartPosition.position;
        arrow.GetComponent<ArrowAndBowScript>().Launch(_mainCamera);
    }
}
