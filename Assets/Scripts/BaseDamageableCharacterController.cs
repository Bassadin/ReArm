using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseDamageableCharacterController : MonoBehaviour
{
    private int currentLifePoints;
    public abstract int getMaxLife();

    public virtual void Awake()
    {
        currentLifePoints = getMaxLife();
    }

    public virtual void changeLife(int changeAmount)
    {
        Debug.Log("Changing life of " + this.gameObject + " by " + changeAmount);
        currentLifePoints = Mathf.Clamp(getLifePoints() + changeAmount, 0, getMaxLife());
        Debug.Log("Life total of  " + this.gameObject + " is now " + currentLifePoints);

        if (currentLifePoints == 0)
        {
            Debug.Log("Triggering onDeath() of  " + this.gameObject);
            onDeath();
        }
    }

    public void dealOneDamage()
    {
        this.changeLife(-1);
    }

    //Don't do anything on death by default
    public abstract void onDeath();

    public int getLifePoints()
    {
        return currentLifePoints;
    }
}
