using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Launcher // INHERITANCE
{
    private float minAngle = -90f;
    private float maxAngle = 0f;
    private Transform rotationCenter;
    private float launchTime = 0.1f;
    private float launchSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        BaseStart();
        rotationCenter = transform.Find("RotationCenter");
        rotationCenter.GetComponentInParent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        BaseUpdate();
        LimitRotation();
    }

    public override void SetLoad() // POLYMORPHISM
    {
        float angle = (maxAngle-minAngle) * currentLoad + minAngle;
        rotationCenter.rotation = Quaternion.Euler(0,0, angle);
        launchSpeed = -(angle-minAngle)/launchTime;
    }

    private void LimitRotation() // ABSTRACTION
    {
        float currentAngle = rotationCenter.rotation.eulerAngles.z;
        if (currentAngle > 180)
        {
            currentAngle = currentAngle - 360;
        }
        if (currentAngle < minAngle)
        {
            rotationCenter.GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rotationCenter.rotation = Quaternion.Euler(0, 0, minAngle);
            isLaunching = false;
        }
        else if (isLaunching)
        {
            rotationCenter.GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, launchSpeed);
        }
    }
}
