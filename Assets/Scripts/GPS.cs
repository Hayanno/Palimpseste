using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
    public float longitude = 0.0f;
    public float latitude = 0.0f;

    // 43.185877, 5.569368 => maison
    Text text;

    void Start() {
        Input.location.Start();
        StartCoroutine(StartGPS());
        text = GetComponent<Text>();
    }

    IEnumerator StartGPS() {
        if (!Input.location.isEnabledByUser)
            yield break;

        // Wait until service initializes
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        
        if (maxWait < 1) {
            print("Timed out");
            yield break;
        }
        
        if (Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            yield break;
        } else {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.latitude;
            text.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        }
    }
}
