using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class dummyCharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController charcterController;
    public float speed = 5;
    void Start()
    {
        charcterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        charcterController.Move(move * Time.deltaTime * speed);
    }
}
