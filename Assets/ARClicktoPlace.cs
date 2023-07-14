using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARClicktoPlace : MonoBehaviour
{
	public GameObject Model;
	public GameObject placementIndicator;
	public ARRaycastManager arRaycast;
	private Pose placementPose;
	public Camera ARCam;
	internal int FlagID;

	void Update()
	{
		var screenCenter = ARCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		var hits = new List<ARRaycastHit>();
		arRaycast.Raycast(screenCenter, hits, TrackableType.Planes);
		if (hits.Count > 0)
		{
			placementPose = hits[0].pose;
			var cameraForward = Camera.main.transform.forward;
			var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
			placementPose.rotation = Quaternion.LookRotation(cameraBearing);
			placementIndicator.SetActive(true);
			placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
		}
		else
		{
			placementIndicator.SetActive(false);
		}
	}

	public void Showmodel() 
	{
		GameObject obj = Instantiate(Model, placementPose.position, placementPose.rotation);
		obj.name = "Flag " + FlagID;
		FlagID++;
	}

}