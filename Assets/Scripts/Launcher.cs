using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Launcher : MonoBehaviour // INHERITANCE
{
    protected float m_currentLoad;
    public float currentLoad // ENCAPSULATION
    {
        get { return m_currentLoad; }
        set {
            if (value > 1)
                m_currentLoad = 1;
            else if (value < 0)
                m_currentLoad = 0;
            else
                m_currentLoad = value;
        }
    }
    protected bool isLaunching = false;
    private bool isProjectileReleased = false;
    public GameObject projectileSpot;
    protected GameObject projectile;

    protected void BaseStart()
    {
        projectile = GameObject.Find("Ball");
    }

    protected void BaseUpdate()
    {
        if (!isProjectileReleased)
        {
            projectile.transform.position = projectileSpot.transform.position;
            projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public abstract void SetLoad(); // POLYMORPHISM // ABSTRACTION

    public virtual void LaunchProjectile() // POLYMORPHISM // ABSTRACTION
    {
        isLaunching = true;
        isProjectileReleased = true;
    }
}
