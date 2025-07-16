using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using SpatialSys.UnitySDK;
using System.Text;
using TMPro;

[Serializable]
public class PositionData
{
    public string userName;
    public string typeEvent;
    public string time;
    public string mode;
    public string date;
    public float posX;
    public float posZ;
}

[Serializable]
public class PositionDataList
{
    public List<PositionData> positions = new List<PositionData>();
}

public class UserPositionTracker : MonoBehaviour
{
    //private IAvatar localAvatar;
    private string userName;
    public TMP_InputField userNameInputField;
    private PositionDataList positionDataList = new PositionDataList();
    public string mode;
    public string typeEvent;
    private float interval = 5f;
    private float timer;
    public bool isRecording = true;
    private float startTime;
    private float totaltime;

    void Start()
    {
        timer = interval;
        //localAvatar = SpatialBridge.actorService.localActor.avatar;
    }

    public void StartRecord ()
    {
        isRecording = true;
    }
    void Update()
    {
        if (isRecording)
        {
            timer -= Time.deltaTime;
            userName = userNameInputField != null ? userNameInputField.text : "DefaultUser";

            if (timer <= 0)
            {
                RecordPosition();
                timer = interval;
            }
        }
    }
    void OnEnable ()
    {
        startTime = Time.time;
    }

    void OnDisable()
    {
        float endTime = Time.time;
        totaltime = endTime - startTime;
    }

    public void StopRecordingAndUpload()
    {
        isRecording = false;
        Debug.Log("Position recording stopped. Uploading data...");
        UploadAllPositions();
    }

    void RecordPosition()
    {
        //Vector3 userPosition = localAvatar.position;
        float currentTime = Time.time - startTime;
        PositionData positionData = new PositionData
        {
            userName = userName,
            date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //posX = userPosition.x,
            //posZ = userPosition.z,
            typeEvent = typeEvent,
            mode = mode,
            time = currentTime.ToString("F2") + " seconds"
        };
        positionDataList.positions.Add(positionData);
    }

    private void UploadAllPositions()
    {
        string jsonData = JsonUtility.ToJson(positionDataList);
        totaltime = Time.time - startTime;
        StartCoroutine(Post("https://salucity-d1352-default-rtdb.firebaseio.com/records.json", jsonData));
    }

    IEnumerator Post(string url, string json)
    {
        byte[] jsonToSend = new UTF8Encoding().GetBytes(json);
        using (UnityWebRequest request = UnityWebRequest.Post(url, UnityWebRequest.kHttpVerbPOST))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error posting data: " + request.error);
            }
            else
            {
                Debug.Log("Data posted successfully!");
                Debug.Log("Response: " + request.downloadHandler.text);
            }
        }
    }
}