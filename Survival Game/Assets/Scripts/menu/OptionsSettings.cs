
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSettings : MonoBehaviour
{
    public Slider volSlider;
    private AudioSource sound;
    public GameObject toggleGroup;
    private int Quality;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 3));
        Quality = QualitySettings.GetQualityLevel();
        sound = GetComponent<AudioSource>();
        volSlider.value = PlayerPrefs.GetFloat("volume", 1);
        if(Quality == 0)
        {
            toggleGroup.transform.Find("Low").gameObject.GetComponent<Toggle>().isOn = true;
        }
        else if (Quality == 3)
        {
            toggleGroup.transform.Find("Medium").gameObject.GetComponent<Toggle>().isOn = true;
        }
        else if (Quality == 5)
        {
            toggleGroup.transform.Find("High").gameObject.GetComponent<Toggle>().isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            saveBtn();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            resetBtn();
        }

        sound.volume = volSlider.value;
    }

    public void low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void medium()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void high()
    {
        QualitySettings.SetQualityLevel(5);
    }

    public void saveBtn()
    {
        PlayerPrefs.SetFloat("volume", volSlider.value);
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        Debug.Log("Options Saved");
    }

    public void resetBtn()
    {
        
    }
}
