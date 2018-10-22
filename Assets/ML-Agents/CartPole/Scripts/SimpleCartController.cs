using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCartController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel

    public void FixedUpdate ()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}
