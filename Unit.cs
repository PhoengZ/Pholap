using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage;
    public int damage1;
    public int damage2;
    public int damage3;
    public int maxHP;
    public int currentHP;
    public int currentdamage;
    public int currentdamage1;
    public int currentdamage2;
    public int currentdamage3;
    public int mindamage;
    
    
    public bool TakeDamage(int dmg){
        currentHP -= dmg;
        if(currentHP <= 0){
            return true;
        }else {
            return false;
        }
    }
    public void Heal(int amount){
        currentHP += amount;
        if(currentHP >= maxHP){
            currentHP = maxHP;
        }
    }
    public void Debuff(int amg){
        damage -= amg;
        if(damage <= 0 ){
            damage = mindamage;
        }
        
    }
    public void Buff(int cdf){
        damage += cdf;
        
    }

}
