using System;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour, ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    private AudioSource audioSource;
    
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        audioSource = GetComponent<AudioSource>();

        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    void OnDestroy() {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            OnTrackingFound();
        } else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                   newStatus == TrackableBehaviour.Status.NOT_FOUND) {
            OnTrackingLost();
        } else {
            OnTrackingLost();
        }
    }

    private void OnTrackingFound() {
        audioSource.Play();
    }

    private void OnTrackingLost() {
        //audioSource.Stop();
    }
}
