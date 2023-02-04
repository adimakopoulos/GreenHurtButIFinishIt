using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    public void doDamage();
    public void takeDamage(int damageAmount);
}
