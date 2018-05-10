using UnityEngine;
using UnityEngine.UI;

public class PopulatePointOfInterests : MonoBehaviour {
    public TextAsset jsonFile;
    public GameObject pointOfInterestCellPrefab;
    public GameObject title;
	public int nbrToInstantiate = 11;
    
    [HideInInspector]
    public Scenario scenario;

    // Use this for initialization
    void Start () {
        Get();
		Populate();
    }

    private void Get() {
        scenario = JsonUtility.FromJson<Scenario>(jsonFile.text);
    }

    private void Populate() {
		GameObject cell;
        GameObject description;

        title.GetComponent<Text>().text = scenario.title;

        foreach (PointOfInterest poi in scenario.pointOfInterests) {
			cell = Instantiate (pointOfInterestCellPrefab, transform);
			description = cell.transform.Find("Description").gameObject;

            description.GetComponent<Text>().text = poi.title;
        }
	}
}
