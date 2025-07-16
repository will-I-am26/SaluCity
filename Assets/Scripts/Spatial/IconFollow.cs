using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SpatialSys.UnitySDK;
public class IconFollow : MonoBehaviour
{
    //private IAvatar localAvatar; 

    void Start()
    {
       // localAvatar = SpatialBridge.actorService.localActor.avatar;
        //cameraService = SpatialBridge.cameraService;
    }

    void LateUpdate()
    {
        //if (localAvatar != null)
        //{
            //Vector3 newPosition = localAvatar.position;
            //newPosition.y = transform.position.y;
            //transform.position = newPosition;
            //transform.rotation = Quaternion.Euler(90f, localAvatar.rotation.eulerAngles.y, 0f);
        //}
    }
}