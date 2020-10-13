using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceThePalace : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject spawnPrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if(Input.touchCount==0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            return;
        }

        if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes)) {
           Pose hitPose = hits[0].pose;

            Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
        };

    }
}
