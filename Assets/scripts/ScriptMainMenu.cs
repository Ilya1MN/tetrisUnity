using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScriptMainMenu : MonoBehaviour
{
    /// <summary>
    /// ����������� ��������
    /// </summary>
    [SerializeField] private Slider sensitivity ;
    /// <summary>
    /// ����� ������
    /// </summary>
    [SerializeField] public TMP_Dropdown modeSelection;

    /// <summary>
    /// ���������� � ��������
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtspeed;
    /// <summary>
    /// ������ �������� ����
    /// </summary>
    public static int height = 20;
    /// <summary>
    /// ������ �������� ����
    /// </summary>
    public static int width ;
    /// <summary>
    /// ����� �������� ����
    /// </summary>
    public static Transform[,] grid;
    private void Awake()
    {
        
        grid = new Transform[PlayerPrefs.GetInt("width1", 10), height];
        width = PlayerPrefs.GetInt("width1", 10);
        modeSelection.value = PlayerPrefs.GetInt("modeSelections", 1);
        sensitivity.value = PlayerPrefs.GetInt("SpeedSelection", 1);
    }


    /// <summary>
    /// ����� ��� ������ � ������������ �������
    /// </summary>
    public void Drops()
    {
        if (modeSelection.value == 0)
        {
            width = 10;
            PlayerPrefs.SetInt("width1", 10);
            grid = new Transform[10, height];
        }
        else
        {
            width = 12;
            PlayerPrefs.SetInt("width1", 12);
            grid = new Transform[12, height];
        }

        grid = new Transform[PlayerPrefs.GetInt("width1", 10), height];
        PlayerPrefs.SetInt("modeSelections", modeSelection.value + 1);

    }
    /// <summary>
    /// ����� ��� ������ �� ���������
    /// </summary>
    public void SlideSpedSel()
    {
       txtspeed.text = $"�������� ��������: {(int)sensitivity.value}";
       PlayerPrefs.SetInt("SpeedSelection", (int)sensitivity.value);
    }

    /// <summary>
    /// ������� �� ����
    /// </summary>
    public void ExitGame()
    {
    
        Application.Quit();
    }

   
}
