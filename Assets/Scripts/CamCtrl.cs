using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    public Transform target;
    public float speed;

    //ī�޶� ���� ����
    public Vector2 minCameraBoundary = new Vector2(-0.19f, -1.89f);
    public Vector2 maxCameraBoundary = new Vector2(100f, 0.97f);

    //Start is called before the first frame update
    void Start()
    {
    
    }

    //Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y + 3f, this.transform.position.z) ;

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);

    }
}
