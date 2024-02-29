using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponHandler[] _weapons;
    private int _currentWeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        _currentWeaponIndex = 0;
        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ToggleWeapon(i);
                break;
            }
        }
    }

    private void ToggleWeapon(int weaponIndex)
    {
        if (weaponIndex < 0 || weaponIndex >= _weapons.Length)
        {
            Debug.LogWarning("Invalid weapon index.");
            return;
        }
        switch (weaponIndex)
        {
            case 0:
                _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;

            case 1:
                if (!WeaponBuy.Instance.Spear)
                    WeaponBuy.Instance.SpearBtn.GetComponent<ButtonUI>().WeaponCount();
                  else
                    _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;
                case 2:
                if (!WeaponBuy.Instance.Bow)
                    WeaponBuy.Instance.BowBtn.GetComponent<ButtonUI>().WeaponCount();
                else
                  _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;
            case 3:
                if (!WeaponBuy.Instance.Revolver)
                    WeaponBuy.Instance.RevolBtn.GetComponent<ButtonUI>().WeaponCount();
                else
                    _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;

                case 4:
                if (!WeaponBuy.Instance.ShoutGun)
                    WeaponBuy.Instance.ShoutBtn.GetComponent<ButtonUI>().WeaponCount();
                else
                    _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;
                case 5:
                if (!WeaponBuy.Instance.Ak)
                    WeaponBuy.Instance.AkBtn.GetComponent<ButtonUI>().WeaponCount();
                else
                    _weapons[weaponIndex].gameObject.SetActive(!_weapons[weaponIndex].gameObject.activeSelf);
                break;


        }
        

        if (_weapons[weaponIndex].gameObject.activeSelf)
        {
            // Eðer seçili silah aktif hale getirildiyse, diðer silahlarýn aktiflik durumunu kapat
            for (int i = 0; i < _weapons.Length; i++)
            {
                if (i != weaponIndex)
                {
                    _weapons[i].gameObject.SetActive(false);
                }
            }
            _currentWeaponIndex = weaponIndex;
        }
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return _weapons[_currentWeaponIndex];
    }
}
