using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GPSDisplay : MonoBehaviour {
    public GameObject gpsGO;
    public float refreshRate = 1f;
    public bool displayLatitude = true;
    public bool displayLongitude = true;

    private GPS gps;
    // 43.185877, 5.569368 => maison
    private Text text;

    // Use this for initialization
    void Start () {
        gps = gpsGO.GetComponent<GPS>();
        text = GetComponent<Text>();

        StartCoroutine(UpdateDisplay());
    }

    IEnumerator UpdateDisplay() {
        for (;;) {
            StringBuilder textToDisplay = new StringBuilder("");

            if (displayLatitude)
                textToDisplay.Append("long : " + Input.location.lastData.longitude);
            if(displayLongitude)
                textToDisplay.Append(" lat : " + Input.location.lastData.latitude);

            text.text = textToDisplay.ToString();

            yield return new WaitForSeconds(refreshRate);
        }
    }
}
