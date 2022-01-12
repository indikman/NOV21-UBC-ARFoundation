using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{
    public GameObject spawnObject;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedObject;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }


    void Update()
    {
        if(spawnedObject == null)
        {
            if (Input.touchCount > 0) // Identify the number of touches
            {
                // Get the touch position
                Vector2 touchPosition = Input.GetTouch(0).position;

                if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    spawnedObject = Instantiate(spawnObject, hitPose.position, hitPose.rotation);
                }
            }

        }



        
    }
}
