using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialScript : MonoBehaviour
{
    public Image dialUI;
    public Color nextDialColor;
    public float colorChangingSpeed = 1f;

    public float dialTurnSpeed = 5f;

    public float currentAngle = 0f;
    public float minAngle1 = -20f;
    public float maxAngle1 = -10f;

    public UnityEvent enableRadioEvent;
    public UnityEvent disableRadioEvent;
    public bool radioEventIsEnabled = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnDial(-dialTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnDial(dialTurnSpeed);
        }

        currentAngle = dialUI.rectTransform.rotation.eulerAngles.z;

        if(currentAngle > minAngle1 && currentAngle < maxAngle1)
        {
            if (!radioEventIsEnabled)
            {
                enableRadioEvent.Invoke();
                radioEventIsEnabled = true;
            }
        }
        else
        {
            if (radioEventIsEnabled)
            { 
                disableRadioEvent.Invoke();
                radioEventIsEnabled = false;
            }
        }

        dialUI.color = Color.Lerp(dialUI.color, nextDialColor, Time.deltaTime * colorChangingSpeed);
    }

    public void ChangeDialColorToRed(bool shouldChange)
    {
        if (shouldChange)
        {
            nextDialColor = Color.red;
        }
        else
        {
            nextDialColor = Color.white;
        }
    }

    private void TurnDial(float dialTurnSpeedInput)
    {
        Quaternion tempDialRotation = dialUI.rectTransform.rotation;
        tempDialRotation.eulerAngles += Vector3.forward * dialTurnSpeedInput * Time.deltaTime;
        dialUI.rectTransform.rotation = tempDialRotation;
    }
}
