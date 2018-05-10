using System;
using UnityEngine;

public class CompassRotation : MonoBehaviour {
    private float lastTrueHeading = 0f;
    public float compassSmooth = 0.5f;

    void Start () {
        Input.compass.enabled = true;
        Input.location.Start();
    }
	
	void Update () {
        float currentTrueHeading = (float) Math.Round(Input.compass.trueHeading, 2);

        if (lastTrueHeading < currentTrueHeading - compassSmooth || lastTrueHeading > currentTrueHeading + compassSmooth) {
            lastTrueHeading = currentTrueHeading;
            transform.localRotation = Quaternion.Euler(0, 0, lastTrueHeading);
        }
    }
}
