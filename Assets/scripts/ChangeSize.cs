using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeSize : MonoBehaviour
{
    /// <summary>
    /// Хранит в себе режим игры
    /// </summary>
    int indexmode;
    /// <summary>
    /// Хранит в себе режим игры
    /// </summary>
    public Transform gamefield;

    private void Awake()
    {
        indexmode = PlayerPrefs.GetInt("modeSelections", 1); //Узнаем какой режим был выбран
        SizeScreen();
    }

    /// <summary>
    /// Изменение игрового поля
    /// </summary>
    public void SizeScreen()
    {
        switch (indexmode)
        {
            case 1:
                //Изменяем расположение игрового поля
                gamefield.position += new Vector3(0f, 0f, 0f);// 0,7 -0.5 0
                  //Изменяем размер игрового поля
                gamefield.localScale += new Vector3(0, 0, 0);
                break;
            case 2: 
                //Изменяем расположение игрового поля
                gamefield.position += new Vector3(1.0f, -0.1f, 0f); // 0.68 -0.6
                //Изменяем размер игрового поля
                gamefield.localScale += new Vector3(2, 0, 0);
                break;

        }
    }
}
