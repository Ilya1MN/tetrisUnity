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
    /// Переменная передающая информацию в текствовое поле "Количество очков"
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtScore;
    /// <summary>
    /// Переменная передающая информацию в текствовое поле "Рекорд"
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtRecordScore;

    /// <summary>
    /// Переменная передающая иформацию о выгрыше/проигрыше
    /// </summary>
    [SerializeField] private TextMeshProUGUI txtWinorFalse;
    /// <summary>
    /// Переменная хранит в себе зачение рекорда
    /// </summary>
    private string savetxtRecordScore = "Record";

    /// <summary>
    /// Количество очков
    /// </summary>
    private int score;
    /// <summary>
    /// Хранит рекорд
    /// </summary>
    private int recscore;
    /// <summary>
    /// Количество очков для выйгрыша
    /// </summary>
    private int winscore = 100;
    /// <summary>
    /// Флаг для опреледеления выйграл игрок или нет
    /// </summary>
    public bool indexwin =  false;
    private void Start()
    {
        InitializedScore();
        InitializedRecordScore();
    }
    /// <summary>
    /// При запуске программы обновляем значение поля "Количество очков"
    /// </summary>
    public void InitializedScore()
    {
        score = 0;
        UpdateScoreText();
    }
    /// <summary>
    /// Добавляем очки
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        
        score += amount;
        UpdateScoreText();
        SaveRecordScore();
    }
    #region Обновление текстовой информации
    /// <summary>
    /// Обновляем поле "Количество очков"
    /// </summary>
    private void UpdateScoreText()
    {
        
        txtScore.text = $"Количество очков:\n{score.ToString()}";
        if (score == winscore)
        {
            txtWinorBad("Вы выйграли!!!");
            indexwin = false;
        }
    }
    /// <summary>
    /// Обновляем поле "Рекорд"
    /// </summary>
    private void UpdateRecordScoreText()
    {
        txtRecordScore.text = $"Рекорд:\n{recscore.ToString()}";
    }
    #endregion
    #region Считывание и запись рекорда
    /// <summary>
    /// При запуске программы обновляем значение поля "Количество очков"
    /// </summary>
    private void InitializedRecordScore()
    {
        recscore = PlayerPrefs.GetInt(savetxtRecordScore, 0) ;
        UpdateRecordScoreText();
    }
    /// <summary>
    /// Записываем новый рекорд
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
    /// Выдаем информацию о том выйграл ли игрок или проиграл
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
