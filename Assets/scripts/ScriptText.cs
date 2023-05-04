using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScriptText : MonoBehaviour
{
    /// <summary>
    /// ���������� ���������� ���������� � ���������� ���� "���������� �����"
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtScore;
    /// <summary>
    /// ���������� ���������� ���������� � ���������� ���� "������"
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtRecordScore;

    /// <summary>
    /// ���������� ���������� ��������� � �������/���������
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtWinorFalse;
    /// <summary>
    /// ���������� ������ � ���� ������� �������
    /// </summary>
    private string savetxtRecordScore = "Record";

    /// <summary>
    /// ���������� �����
    /// </summary>
    private int score;
    /// <summary>
    /// ������ ������
    /// </summary>
    private int recscore;
    /// <summary>
    /// ���������� ����� ��� ��������
    /// </summary>
    private int winscore = 100;
    /// <summary>
    /// ���� ��� ������������� ������� ����� ��� ���
    /// </summary>
    public bool indexwin =  false;
    private void Start()
    {
        InitializedScore();
        InitializedRecordScore();
    }
    /// <summary>
    /// ��� ������� ��������� ��������� �������� ���� "���������� �����"
    /// </summary>
    public void InitializedScore()
    {
        score = 0;
        UpdateScoreText();
    }
    /// <summary>
    /// ��������� ����
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        
        score += amount;
        UpdateScoreText();
        SaveRecordScore();
    }
    #region ���������� ��������� ����������
    /// <summary>
    /// ��������� ���� "���������� �����"
    /// </summary>
    private void UpdateScoreText()
    {
        
        txtScore.text = $"���������� �����:\n{score.ToString()}";
        if (score == winscore)
        {
            txtWinorBad("�� ��������!!!");
            indexwin = false;
        }
    }
    /// <summary>
    /// ��������� ���� "������"
    /// </summary>
    private void UpdateRecordScoreText()
    {
        txtRecordScore.text = $"������:\n{recscore.ToString()}";
    }
    #endregion
    #region ���������� � ������ �������
    /// <summary>
    /// ��� ������� ��������� ��������� �������� ���� "���������� �����"
    /// </summary>
    private void InitializedRecordScore()
    {
        recscore = PlayerPrefs.GetInt(savetxtRecordScore, 0) ;
        UpdateRecordScoreText();
    }
    /// <summary>
    /// ���������� ����� ������
    /// </summary>
    private void SaveRecordScore()
    {
        if (score > recscore)
        {

            PlayerPrefs.SetInt(savetxtRecordScore, score);
            UpdateRecordScoreText();
        }
    }
    #endregion
    /// <summary>
    /// ������ ���������� � ��� ������� �� ����� ��� ��������
    /// </summary>
    /// <param name="info"></param>
    public void txtWinorBad(string info)
    {
        if (txtWinorFalse.color != null)
            txtWinorFalse.color = Color.black;

        if (indexwin == false)
        {
            txtWinorFalse.text = info;
        }
        else
        {
            txtWinorFalse.text = info;
        }
    }
  
}
