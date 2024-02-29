using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public int GunMoney;
    public ItemType ItemType;
    public Text Buytext;
    public Text IdText;

    private void Start()
    {
         if(Buytext != null)
        Buytext.text=GunMoney.ToString()+" $";
    }
    public void WeaponCount()
    {
        int totalmoney = MoneyManager.Instance.MoneyCount;
        if (ItemType == ItemType.Spear && !WeaponBuy.Instance.Spear && totalmoney >= GunMoney)
        {
            WeaponBuy.Instance.Spear = true;
            Buytext.gameObject.SetActive(false);
            IdText.gameObject.SetActive(true);
            GetComponent<Button>().image.color = Color.white;
            PlayerPrefs.SetInt(Weapons.Spear, 2);
            MoneyManager.Instance.AddMoney(-GunMoney);

        }
        if (ItemType == ItemType.Bow && !WeaponBuy.Instance.Bow && totalmoney >= GunMoney)
        {
            WeaponBuy.Instance.Bow = true;
            Buytext.gameObject.SetActive(false);
            IdText.gameObject.SetActive(true);
            GetComponent<Button>().image.color = Color.white;
            PlayerPrefs.SetInt(Weapons.Bow, 3);
            MoneyManager.Instance.AddMoney(-GunMoney);
        }
        if (ItemType == ItemType.Revolver && !WeaponBuy.Instance.Revolver && totalmoney >= GunMoney)
        {
            WeaponBuy.Instance.Revolver = true;
            Buytext.gameObject.SetActive(false);
            IdText.gameObject.SetActive(true);
            GetComponent<Button>().image.color = Color.white;
            PlayerPrefs.SetInt(Weapons.Revolver, 4);
            MoneyManager.Instance.AddMoney(-GunMoney);
        }
        if (ItemType == ItemType.ShoutGun && !WeaponBuy.Instance.ShoutGun && totalmoney >= GunMoney)
        {
            WeaponBuy.Instance.ShoutGun = true;
            Buytext.gameObject.SetActive(false);
            IdText.gameObject.SetActive(true);
            GetComponent<Button>().image.color = Color.white;
            PlayerPrefs.SetInt(Weapons.ShoutGun, 5);
            MoneyManager.Instance.AddMoney(-GunMoney);
        }
        if (ItemType == ItemType.Ak && !WeaponBuy.Instance.Ak && totalmoney >= GunMoney)
        {
            WeaponBuy.Instance.Ak = true;
            Buytext.gameObject.SetActive(false);
            IdText.gameObject.SetActive(true);
            GetComponent<Button>().image.color = Color.white;
            PlayerPrefs.SetInt(Weapons.Ak, 6);
            MoneyManager.Instance.AddMoney(-GunMoney);
        }
    }
}
