using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigBox : MonoBehaviour
{
    public Button m_Close_Btn = null;
    public Button m_DiscriptionBtn = null;
    public Button m_GameEndBtn = null;

    public Toggle m_Sound_Toggle = null;
    public Slider m_Sound_Slider = null;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Close_Btn != null)
            m_Close_Btn.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;
                Destroy(gameObject);
            });

        if (m_DiscriptionBtn != null)
            m_DiscriptionBtn.onClick.AddListener(() =>
            {

            });

        if (m_GameEndBtn != null)
            m_GameEndBtn.onClick.AddListener(() =>
            {
                if (Fade_Mgr.Inst != null && Fade_Mgr.Inst.IsFadeOut == true)
                    Fade_Mgr.Inst.SceneOut("TitleScene");
                else
                    SceneManager.LoadScene("TitleScene");
            });

        // üũ ���°� ����Ǿ��� �� ȣ��Ǵ� �Լ��� ����ϴ� �ڵ�
        if (m_Sound_Toggle != null)
            m_Sound_Toggle.onValueChanged.AddListener(SoundOnOff);

        //�����̵� ���°� ����Ǿ��� �� ȣ��Ǵ� �Լ� ����ϴ� �ڵ�
        if (m_Sound_Slider != null)
            m_Sound_Slider.onValueChanged.AddListener(SliderChanged);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void SoundOnOff(bool value) // üũ ���°� ����Ǿ��� �� ȣ��ǰ� �� �Լ�
    {
        if(m_Sound_Toggle != null)
        {
            if (value == true)
                PlayerPrefs.SetInt("SoundOnOff", 1);
            else
                PlayerPrefs.SetInt("SoundOnOff", 0);

            Sound_Mgr.Instance.SoundOnOff(value);
        }
    }

    void SliderChanged(float value)
    {
        PlayerPrefs.SetFloat("SoundVolume", value);
        Sound_Mgr.Instance.SoundVolume(value);
    }
}
