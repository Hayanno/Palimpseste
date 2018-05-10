using System.Collections;
using UnityEngine;

public class GPS : MonoBehaviour {
    public float refreshRate = 1f;
    public int timeOutInSecond = 20;

    [HideInInspector]
    public float longitude = 0.0f;
    [HideInInspector]
    public float latitude = 0.0f;

    void Start() {
        Input.location.Start();
        StartCoroutine(StartGPS());
    }

    IEnumerator StartGPS() {
        if (!Input.location.isEnabledByUser)
            yield break;

        // Wait until service initializes
        int maxWait = timeOutInSecond;

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
            StartCoroutine(UpdateData());
        }
    }

    IEnumerator UpdateData() {
        for (;;) {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.latitude;
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
