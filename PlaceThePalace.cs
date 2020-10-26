using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceThePalace : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject spawnPrefab;
    public Pose m_spawnprefabPose;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public bool GhostTrigger=false;

    void Update()
    {

        if(Input.touchCount==0 | GhostTrigger == true)
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
            m_spawnprefabPose= hits[0].pose; //유령생성 위치의 기준점 pose
            GhostTrigger = true;


            Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);

            //transform.position = hitPose.position;
            //transform.rotation = hitPose.rotation;
            //GhostList[0].transform.position = hitPose.position;
        };

        
    }
}
