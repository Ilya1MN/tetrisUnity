using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ScriptMovement : MonoBehaviour
{
    private ScriptText scriptText;
    /// <summary>
    /// ���������� ���������� ���������� � ���������� ���� "���������� �����"
    /// </summary>
    [SerializeField] private TextMeshPro txtScore; 
    /// <summary>
    /// ���������� ���������� ���������� � ���������� ���� "������"
    /// </summary>
    [SerializeField] private TextMeshPro txtRecordScore;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TextMeshPro txtWinorFalse;

    /// <summary>
    /// ������ ����� �� ��������
    /// </summary>
    private float previosTime;
    /// <summary>
    /// �����
    /// </summary>
    public float failTime = 0.8f;
    /// <summary>
    /// ������� ����� �� ������
    /// </summary>
    private static int height;
    /// <summary>
    /// ������� ����� �� ������
    /// </summary>
    private static int width; 
    /// <summary>
    /// ���������� ��� ����������
    /// </summary>
    public Vector3 rotatepoint;
    /// <summary>
    /// ������ � ���� ���������� � �������� ���������
    /// </summary>
  //  private static Transform[,] grid = new Transform[width, height];
    /// <summary>
    /// ������ � ���� ����� ����
    /// </summary>
    int indexmode;
    /// <summary>
    /// ��������
    /// </summary>
    int speed;


    // Start is called before the first frame update
    void Start()
    {
        width = ScriptMainMenu.width;
        height = ScriptMainMenu.height;

        scriptText = FindAnyObjectByType<ScriptText>();

        indexmode = PlayerPrefs.GetInt("modeSelections", 1); //������ ����� ����� ��� ������
        speed = PlayerPrefs.GetInt("SpeedSelection", 1);
  
    }



    // Update is called once per frame
    void Update()
    {

        //��������� �� �������� �����
        switch (indexmode)
        {
            case 1:
                Mode1();
                break;
            case 2:
                Mode2();
                break;
        }
    
    }


    /// <summary>
    /// ����� 1
    /// </summary>
    private void Mode1()
    {
 
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (Time.time - previosTime > failTime / speed))//�������� ����� �  ������� �������������� ��������
        {
            transform.position += new Vector3(-1, 0, 0);//transform.right //��������� ����� 
            if (!ValidMove()) // ���� �������� ����, �� ���������������
                transform.position -= new Vector3(-1, 0, 0);// / failTime;//transform.right // ���������
            previosTime = Time.time; // ����������� �������� �����
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (Time.time - previosTime > failTime / speed))//�������� ������ �  ������� �������������� ��������
        {
            transform.position += new Vector3(1, 0, 0);// / failTime;//transform.right  //��������� ������ 
            if (!ValidMove())// ���� �������� ����, �� ���������������
                transform.position -= new Vector3(1, 0, 0);// / failTime;//transform.right  // ���������

            previosTime = Time.time; // ����������� �������� �����
        }
        Mode1Mode2();

    }
    /// <summary>
    /// ����� 2
    /// </summary>
    private void Mode2()
    {
  

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (Time.time - previosTime > failTime / speed))//�������� ����� �  ������� �������������� ��������
        {
            transform.position += new Vector3(-1, 0, 0);//transform.right //��������� �����

            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);//���������� ���������� �� �

     
                if (roundedX < 0) // ���� �������� ���� ���������� �������� ������� ������
                   children.position += new Vector3(12, 0, 0);
            }
            if (!ValidMove())// ���� �������� ����, �� ���������������
                transform.position -= new Vector3(-1, 0, 0);// / failTime;//transform.right  // ���������
            previosTime = Time.time; // ����������� �������� �����
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (Time.time - previosTime > failTime / speed))//�������� ������ �  ������� �������������� ��������
        {
            transform.position += new Vector3(1, 0, 0);// / failTime;//transform.right  //��������� ������ 
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);//���������� ���������� �� �

 
                if (roundedX == width  )// ���� �������� ���� ���������� �������� ������� �����
                    children.position += new Vector3( -12, 0, 0);
            }
            if (!ValidMove())// ���� �������� ����, �� ���������������
                transform.position -= new Vector3(1, 0, 0);// / failTime;//transform.right  // ���������


            previosTime = Time.time; // ����������� �������� �����
        }
        Mode1Mode2();

    }
    private void Mode1Mode2()
    {
        if (Input.GetKey(KeyCode.A) && (Time.time - previosTime > failTime / speed)) // ������������ ����� �  ������� �������������� ��������
        {
            transform.RotateAround(transform.TransformPoint(rotatepoint), new Vector3(0, 0, 1), 90); // ������������ ����� ������ ������� ������� �� 90 ��������
            previosTime = Time.time; // ����������� �������� �����
        }

        if (Input.GetKey(KeyCode.D) && (Time.time - previosTime > failTime / speed)) // ������������ ������ �  ������� �������������� ��������
        {

            transform.RotateAround(transform.TransformPoint(rotatepoint), new Vector3(0, 0, 1), -90);// ������������ ������ �� ������� ������� �� 90 ��������
            previosTime = Time.time; // ����������� �������� �����
        }


        if (Time.time - previosTime > (Input.GetKey(KeyCode.DownArrow) ? failTime / speed : failTime)) //�������� ���� � ���� ������ ������ ����������, ����� ���� �� ��������
     
        {
            transform.position += new Vector3(0, -1, 0); // ��������� ����
            if (!ValidMove()) // ��������� �������� ���� ��� ���, ���� �� �� ���������������
            {
                transform.position -= new Vector3(0, -1, 0); // ���������

                if (transform.position.y < 18 )
                {
                     AddToGrid();// ���������� ��� ��� ���� ������
             
                    if (indexmode == 1)
                    {

                        CheckForLinesMode1();//�������� ������� �� �����
                    }
                    else
                    {

                        CheckForLinesMode2();
                    }
                    this.enabled = false;
                    FindObjectOfType<SpawnerObject>().NewObject();//��������� �� ����� ����� ������
                }
                else if (transform.position.y >= 18 )
                { 
                    scriptText.indexwin = true;

                    scriptText.txtWinorBad("�� ���������!!!");
                   
                }
            }

            previosTime = Time.time; // ����������� �������� �����
        }
    }
    #region �������� � �������� ���������� ������
    /// <summary>
    /// ���������� �� ����� � ������� ���� �� ��������� �����, ���� �� �� ������� ��
    /// </summary>
    private void CheckForLinesMode1()
    {

        for (int i = height - 1; i >= 0; i--)
        {
   
            if (HasLine(i) )//���� ����� ����� ������� ������� �� � ��������� ����
            {
                 DeleteLine(i);
                 RowDown(i);
            
                scriptText.AddScore(i * i);//� ����������� �� ���� �� ����� ������ ���� ������� ������ ������� ����� � ����� ���������
            }
        }
    }
    /// <summary>
    /// ���������� �� ����� � ������� ���� �� ��������� �����, ���� �� �� ������� ��
    /// </summary>
    private void CheckForLinesMode2()
    {

        for (int i = height - 1; i >= 0; i -=2)
        {
            //Debug.Log(HasLine(i) + "  " +  HasLine(i + 1));
            if (HasLine(i) && HasLine(i - 1))//���� ����� ����� ������� ������� �� � ��������� ����
            {
                DeleteLine(i);
                RowDown(i);

                DeleteLine(i  - 1);
                RowDown(i - 1);
                scriptText.AddScore((i + 1) * (i + 1));//� ����������� �� ���� �� ����� ������ ���� ������� ������ ������� ����� � ����� ���������
            }
        }
    }
    /// <summary>
    /// ��������� ���� �� ��������� �����
    /// </summary>
    /// <param name="i">������ �������� ����� �� ������</param>
    /// <returns>���������� true/false � ����������� �� ���� ���� �� ������ ������ � ������</returns>
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
          
            if (ScriptMainMenu.grid[j ,i] == null)//���� ������ null ������ ���� ������ ������
            {
      
                return false;
            }
        }
        //���� ��� ������ ��� ������ � ����� ���������
        return true;
    }
    /// <summary>
    /// �������� ��������� ����� 
    /// </summary>
    /// <param name="i">������ �������� ����� �� ������</param>
    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(ScriptMainMenu.grid[j, i].gameObject);
            ScriptMainMenu.grid[j, i] = null;


        }

    }
    /// <summary>
    /// �������� �� ����� � ��������� ����
    /// </summary>
    /// <param name="i">������ �������� ����� �� ������</param>
    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (ScriptMainMenu.grid[j, y] != null)
                {   
                    ScriptMainMenu.grid[j, y - 1] = ScriptMainMenu.grid[j, y];
                    ScriptMainMenu.grid[j, y] = null;
                    ScriptMainMenu.grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    #endregion
    #region ��������� ������� ������ � �������� ��������
    /// <summary>
    /// ��������� � ������ �������� �������
    /// </summary>
    private void AddToGrid()
    {
       
     

        foreach (Transform children in transform)
        {
            
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if (roundedX == -1)
                roundedX = 0;
       
     
             ScriptMainMenu.grid[roundedX, roundedY] = children;
            
 
        }
    }
    #endregion
    #region �������� ��������
    /// <summary>
    /// �������� �� ����
    /// </summary>
    /// <returns>���������� true/false � ����������� �� ���� �������� �� ������ ���� ��� ���, � ���� �� ����� ������ �� ������� ������������ ��� ���, ���� ���� �� ���������� false</returns>
    bool ValidMove()
    {

  
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);//���������� ���������� �� �
            int roundedY = Mathf.RoundToInt(children.transform.position.y);// ���������� ���������� �� Y
            
   
            if (roundedX < 0 || roundedX >= width  || roundedY < 0 || roundedY >= height)//������ ������� �� ������� ������ ��������
            {
                return false;
            }
   
            if (roundedX == -1)
            {
                roundedX = 0;
            }

            if (roundedX == width + 1)
            {
                roundedX = width;
            }
                
            if (ScriptMainMenu.grid[roundedX, roundedY] != null)// ��������� �� ����� ����������� ���� ������ ��� ���
            {
                return false;
            }
        }
        return true;
    }

    #endregion



}
