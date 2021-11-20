using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    
    public bool PlaceTower(Tower tower, Vector3 instPos) 
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(cost > bank.CurrentBalance)
        {
            return false;
        }

        Instantiate(tower, instPos, Quaternion.identity);
        bank.Withdraw(cost);
        return true;
    }
}
