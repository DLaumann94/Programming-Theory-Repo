using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Launcher
{
    private float minPos = 0f;
    private float maxPos = -2f;
    private Transform box;
    private float launchTime = 0.1f;
    private float launchSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        BaseStart();
        box = transform.Find("Box");
    }

    // Update is called once per frame
    void Update()
    {
        BaseUpdate();
        LimitPosition();
    }

    public override void SetLoad(float load)
    {
        float position = (maxPos - minPos) * load + minPos;
        box.localPosition = new Vector3(position, box.localPosition.y, box.localPosition.z);
        launchSpeed = -(position - minPos) / launchTime;
    }



    private void LimitPosition()
    {
        if (box.localPosition.x > minPos)
        {
            box.GetComponentInParent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            box.localPosition = new Vector3(minPos, box.localPosition.y, box.localPosition.z);
            isLaunching = false;
        }
        else if (isLaunching)
        {
            box.GetComponentInParent<Rigidbody>().velocity = transform.right * launchSpeed;
        }
    }
}
