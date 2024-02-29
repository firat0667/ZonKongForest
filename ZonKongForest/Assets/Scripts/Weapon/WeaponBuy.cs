using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Axe,
    Spear,
    Bow,
    Revolver,
    ShoutGun,
    Ak
}

public class WeaponBuy : MonoBehaviour
{
    public bool Spear;
    public bool Bow;
    public bool Revolver;
    public bool ShoutGun;
    public bool Ak;

    public Button SpearBtn;
    public Button BowBtn;
    public Button RevolBtn;
    public Button ShoutBtn;
    public Button AkBtn;

    public static WeaponBuy Instance;
        private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        WeaponOpened(ItemType.Spear);
        WeaponOpened(ItemType.Bow);
        WeaponOpened(ItemType.Revolver);
        WeaponOpened(ItemType.ShoutGun);
        WeaponOpened(ItemType.Ak);
    }

    public void WeaponOpened(ItemType ýtemType)
    {
        switch (ýtemType)
        {
            case ItemType.Spear:
                int spear = PlayerPrefs.GetInt(Weapons.Spear);
                if (spear ==2)
                {
                    Spear = true;
                   SpearBtn.GetComponent<Button>().image.color = Color.white;
                   SpearBtn.GetComponent<ButtonUI>().IdText.gameObject.SetActive(true);
                   SpearBtn.GetComponent<ButtonUI>().Buytext.gameObject.SetActive(false);
                }
                break;

                case ItemType.Bow:
                int bow = PlayerPrefs.GetInt(Weapons.Bow);
                if (bow == 3)
                {
                    Bow = true;
                    BowBtn.GetComponent<Button>().image.color = Color.white;
                    BowBtn.GetComponent<ButtonUI>().IdText.gameObject.SetActive(true);
                    BowBtn.GetComponent<ButtonUI>().Buytext.gameObject.SetActive(false);
                }
                break;

                case ItemType.Revolver:
                int revolver = PlayerPrefs.GetInt(Weapons.Revolver);
                if (revolver == 4)
                {
                    Revolver = true;
                    RevolBtn.GetComponent<Button>().image.color = Color.white;
                    RevolBtn.GetComponent<ButtonUI>().IdText.gameObject.SetActive(true);
                    RevolBtn.GetComponent<ButtonUI>().Buytext.gameObject.SetActive(false);
                }
                break;
                case ItemType.ShoutGun:
                int shoutgun = PlayerPrefs.GetInt(Weapons.ShoutGun);
                if (shoutgun == 5)
                {
                    ShoutGun = true;
                    ShoutBtn.GetComponent<Button>().image.color = Color.white;
                    ShoutBtn.GetComponent<ButtonUI>().IdText.gameObject.SetActive(true);
                    ShoutBtn.GetComponent<ButtonUI>().Buytext.gameObject.SetActive(false);
                }
                break;
                case ItemType.Ak:
                int ak = PlayerPrefs.GetInt(Weapons.Ak);
                if (ak == 6)
                {
                    Ak = true;
                    AkBtn.GetComponent<Button>().image.color = Color.white;
                    AkBtn.GetComponent<ButtonUI>().IdText.gameObject.SetActive(true);
                    AkBtn.GetComponent<ButtonUI>().Buytext.gameObject.SetActive(false);
                }
                break;
        }
    }
}
