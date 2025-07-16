using UnityEngine;
//using SpatialSys.UnitySDK;

public class FaceCameraX : MonoBehaviour
{
    //private ICameraService cameraService;
    private GameObject rotationParent;
    public Transform rotationCenter;

    void Start()
    {
        //cameraService = SpatialBridge.cameraService;

        rotationParent = new GameObject("RotationParent");

        if (rotationCenter != null)
        {
            rotationParent.transform.position = rotationCenter.position;
            transform.SetParent(rotationParent.transform);
            transform.localPosition = transform.position - rotationCenter.position;
        }
    }

    void Update()
    {
        /*if (cameraService != null && rotationCenter != null)
        {
            Vector3 cameraPosition = cameraService.position;

            Vector3 directionToCamera = cameraPosition - rotationParent.transform.position;
            directionToCamera.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            Quaternion rotationOffset = Quaternion.Euler(0, -90, 0);
            targetRotation = targetRotation * rotationOffset;
            rotationParent.transform.rotation = Quaternion.Slerp(rotationParent.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }*/
    }
}