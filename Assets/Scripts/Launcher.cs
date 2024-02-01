using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Launcher : MonoBehaviour
{
    protected float currentLoad;
    protected bool isLaunching = false;
    public GameObject projectileSpot;
    protected GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunching)
        {
            projectile.transform.position = projectileSpot.transform.position;
        }
    }

    public abstract void SetLoad(float loadValue);

    public virtual void LaunchProjectile()
    {
        isLaunching = true;
    }

    public void ResetLauncher()
    {
        isLaunching = false;
        SetLoad(0);
        projectile.transform.position = projectileSpot.transform.position;
    }
}
