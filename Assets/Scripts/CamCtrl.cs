using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{ 
    //��ũ���� ���� ��ǥ
    public static Vector3 m_ScreenWMin = new Vector3(-20.0f, -6.0f, 0.0f);
    public static Vector3 m_ScreenWMax = new Vector3(20f, 6.0f, 0.0f);
    //��ũ���� ���� ��ǥ

    public Transform target;
    public float speed;

    //ī�޶� ���� ����
    public Vector2 center;
    public Vector2 size;

    public static Vector3 CamVec;

    float height;   //ī�޶��� ���� ����
    float width;    //���� ����

    //Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;  //���弼�� * ��ũ�� ���� / ��ũ�� ����
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    //Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); //ī�޶�� �÷��̾� ������ ���� �� ��ȯ
        transform.position = new Vector3(transform.position.x, 0, -10f);

        float clampX = Mathf.Clamp(transform.position.x, 0, width * 1000);    //Mathf.Clamp(value, min, max)
        float ly = size.y * 0.5f - height;  //size.y�� ���ݰ� - ����
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);
        transform.position = new Vector3(clampX, clampY, -10f);
        CamVec = transform.position;
    }
}
