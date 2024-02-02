using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : Launcher // INHERITANCE
{
    private float minAngle = 0f;
    private float maxAngle = -90f;
    private Transform rotationCenter;
    private float launchTime = 0.1f;
    private float launchSpeed = 0f;
    private float overshootAngle = 10f;

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
        float angle = (maxAngle - minAngle) * currentLoad + minAngle;
        rotationCenter.rotation = Quaternion.Euler(0, 0, angle);
        launchSpeed = -(angle - minAngle) / launchTime;
    }

    private void LimitRotation() // ABSTRACTION
    {
        float currentAngle = rotationCenter.rotation.eulerAngles.z;
        if (currentAngle > 180)
        {
            currentAngle = currentAngle - 360;
        }
        if (currentAngle > minAngle+overshootAngle)
        {
            rotationCenter.GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            isLaunching = false;
        }
        else if (isLaunching)
        {
            rotationCenter.GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, launchSpeed);
        }
    }
}
