using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bubbleWeapon;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            bubbleWeapon.SetActive(true);
        }
        else
        {
            bubbleWeapon.SetActive(false);
        }
    }
}
