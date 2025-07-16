using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SpatialSys.UnitySDK;

public class Teleport : MonoBehaviour
{
    //private IAvatar localAvatar;
    public Transform targetPosition;

    void Start()
    {
        // 初始化 localAvatar
        //if (SpatialBridge.actorService.localActor != null)
        //{
            //localAvatar = SpatialBridge.actorService.localActor.avatar;
        //}
        //else
        //{
            //Debug.LogWarning("localActor is not available. Teleport script cannot initialize.");
        //}
    }

    public void TeleportToTarget()
    {
        //if (localAvatar == null)
        //{
            //Debug.LogWarning("localAvatar is not initialized. Cannot teleport.");
            //return;
        //}

        //if (targetPosition == null)
        //{
            //Debug.LogWarning("Target position is not set. Cannot teleport.");
            //return;
        //}

        //localAvatar.position = targetPosition.position;
        //Debug.Log("Avatar teleported to: " + targetPosition.position);
    }
}