using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Launcher : MonoBehaviour
{
    protected float currentLoad;
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

    public abstract void SetLoad(float loadValue);

    public virtual void LaunchProjectile()
    {
        isLaunching = true;
        isProjectileReleased = true;
    }
}
