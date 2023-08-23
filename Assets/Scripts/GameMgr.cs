using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameLevel
{
    Level1,
    Boss
}

public class GameMgr : MonoBehaviour
{
    //---- ĳ���� �Ӹ� ���� ������ ����� ���� ����
    GameObject m_DmgClone;  //Damage Text ���纻�� ���� ����
    DmgTextCtrl m_DmgText;  //Damage Text ���纻�� �ִ� DmgText_Ctrl ������Ʈ�� ���� ����
    Vector3 m_StCacPos;     //���� ��ġ�� ����� �ֱ� ���� ����
    [Header("--- Damage Text ---")]
    public Transform m_Damage_Canvas = null;    //Damage_Canvas
    public GameObject m_DamageRoot = null;      //Damage������

    // ---- ���� -----
    [Header(" ---- Store ----- ")]
    public Button m_StoreBtn = null;
    public GameObject m_StorePanel = null;
    public Button m_ExitBtn = null;

    public GameObject m_CoinItem = null;
    public Text m_GoldText = null;
    int m_CurGold = 0;

    public static GameMgr Inst = null;

    public static GameLevel m_gameLevel = GameLevel.Level1;
    void Awake()
    {
        Inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        if (m_StoreBtn != null)
            m_StoreBtn.onClick.AddListener(StorePanel);

    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void DamageText(float a_Value, Vector3 a_Pos, Color a_color)
    {
        if (m_Damage_Canvas == null || m_DamageRoot == null)
            return;

        m_DmgClone = (GameObject)Instantiate(m_DamageRoot); //DmgTextRoot ����
        m_DmgClone.transform.SetParent(m_Damage_Canvas);    //m_Damage_Canvas�� �ٿ�
        m_DmgText = m_DmgClone.GetComponent<DmgTextCtrl>();
        if (m_DmgText != null)
            m_DmgText.InitDamage(a_Value, a_color);
        m_StCacPos = new Vector3(a_Pos.x, a_Pos.y + 1.4f, 0.0f);
        m_DmgClone.transform.position = m_StCacPos;

    }
    void StorePanel()
    {
        if (m_StorePanel != null)
            m_StorePanel.SetActive(true);

        Time.timeScale = 0.0f;

    }

    public void SpawnCoin(Vector3 a_Pos)
    {
        if (m_CoinItem == null)
            return;

        GameObject a_CoinObj = Instantiate(m_CoinItem) as GameObject;
        a_CoinObj.transform.position = a_Pos;
        Destroy(a_CoinObj, 10.0f);
    }

    public void AddGold(int value = 10)
    {
        m_CurGold += value;
        if (m_CurGold < 0)
            m_CurGold = 0;

        //GlobalValue.g_UserGold += value;

        //if (GlobalValue.g_UserGold <= 0)
        //    GlobalValue.g_UserGold = 0;

        m_GoldText.text = m_CurGold.ToString();
    }
}
