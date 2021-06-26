using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{

    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのPosition取得
        float playerPosX = playerObject.transform.position.x;//float
        float playerPosY = playerObject.transform.position.y+2;//float
                                                             //追尾可能範囲の制限をしたPositionを取得
        float cameraPosX = playerPosX;// Mathf.Clamp(playerPosX, 0, 60);//41
        float cameraPosY = playerPosY; //Mathf.Clamp(playerPosY, -7, 40);//10
        //カメラのPosition(Z)取得



        float posZ = transform.position.z;
        //プレイヤーのPoritionをカメラにセット
        this.transform.position = new Vector3(cameraPosX, cameraPosY, posZ);
    }
}
