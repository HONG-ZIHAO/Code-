using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    GameObject playerObj;
    PlayerCon player;
    Transform playerTransform;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerCon>();
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //横方向だけ追従
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}

