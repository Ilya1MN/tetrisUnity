using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeSize : MonoBehaviour
{
    /// <summary>
    /// ������ � ���� ����� ����
    /// </summary>
    int indexmode;
    /// <summary>
    /// ������ � ���� ����� ����
    /// </summary>
    public Transform gamefield;

    private void Awake()
    {
        indexmode = PlayerPrefs.GetInt("modeSelections", 1); //������ ����� ����� ��� ������
        SizeScreen();
    }

    /// <summary>
    /// ��������� �������� ����
    /// </summary>
    public void SizeScreen()
    {
        switch (indexmode)
        {
            case 1:
                //�������� ������������ �������� ����
                gamefield.position += new Vector3(0f, 0f, 0f);// 0,7 -0.5 0
                  //�������� ������ �������� ����
                gamefield.localScale += new Vector3(0, 0, 0);
                break;
            case 2: 
                //�������� ������������ �������� ����
                gamefield.position += new Vector3(1.0f, -0.1f, 0f); // 0.68 -0.6
                //�������� ������ �������� ����
                gamefield.localScale += new Vector3(2, 0, 0);
                break;

        }
    }
}
