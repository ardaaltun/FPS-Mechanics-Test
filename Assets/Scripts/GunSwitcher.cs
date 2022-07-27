using System;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{

    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
            #region GUN SWITCH
            int previousWeapon = selectedWeapon;
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                selectedWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
            {
                selectedWeapon = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 2)
            {
                selectedWeapon = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 2)
            {
                selectedWeapon = 4;
            }
            if (previousWeapon != selectedWeapon)
                SelectWeapon();
            #endregion
        

    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
