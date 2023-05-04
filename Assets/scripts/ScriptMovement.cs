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
    /// Переменная передающая информацию в текствовое поле "Количество очков"
    /// </summary>
    [SerializeField] private TextMeshPro txtScore; 
    /// <summary>
    /// Переменная передающая информацию в текствовое поле "Рекорд"
    /// </summary>
    [SerializeField] private TextMeshPro txtRecordScore;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TextMeshPro txtWinorFalse;

    /// <summary>
    /// Хранит время до текущего
    /// </summary>
    private float previosTime;
    /// <summary>
    /// Время
    /// </summary>
    public float failTime = 0.8f;
    /// <summary>
    /// Размеры сетки по высоте
    /// </summary>
    private static int height;
    /// <summary>
    /// Размеры сетки по ширине
    /// </summary>
    private static int width; 
    /// <summary>
    /// Переменная для поповорота
    /// </summary>
    public Vector3 rotatepoint;
    /// <summary>
    /// Хранит в себе информацию о дочерних элементах
    /// </summary>
  //  private static Transform[,] grid = new Transform[width, height];
    /// <summary>
    /// Хранит в себе режим игры
    /// </summary>
    int indexmode;
    /// <summary>
    /// Скорость
    /// </summary>
    int speed;


    // Start is called before the first frame update
    void Start()
    {
        width = ScriptMainMenu.width;
        height = ScriptMainMenu.height;

        scriptText = FindAnyObjectByType<ScriptText>();

        indexmode = PlayerPrefs.GetInt("modeSelections", 1); //Узнаем какой режим был выбран
        speed = PlayerPrefs.GetInt("SpeedSelection", 1);
  
    }



    // Update is called once per frame
    void Update()
    {

        //Переходим на выбанный режим
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
    /// Режим 1
    /// </summary>
    private void Mode1()
    {
 
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (Time.time - previosTime > failTime / speed))//Движение влево и  немного притормаживаем движение
        {
            transform.position += new Vector3(-1, 0, 0);//transform.right //двигаемся влево 
            if (!ValidMove()) // если достигли края, то останавливаемся
                transform.position -= new Vector3(-1, 0, 0);// / failTime;//transform.right // остановка
            previosTime = Time.time; // отслеживаем реальное время
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (Time.time - previosTime > failTime / speed))//Движение вправо и  немного притормаживаем движение
        {
            transform.position += new Vector3(1, 0, 0);// / failTime;//transform.right  //двигаемся вправо 
            if (!ValidMove())// если достигли края, то останавливаемся
                transform.position -= new Vector3(1, 0, 0);// / failTime;//transform.right  // остановка

            previosTime = Time.time; // отслеживаем реальное время
        }
        Mode1Mode2();

    }
    /// <summary>
    /// Режим 2
    /// </summary>
    private void Mode2()
    {
  

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (Time.time - previosTime > failTime / speed))//Движение влево и  немного притормаживаем движение
        {
            transform.position += new Vector3(-1, 0, 0);//transform.right //двигаемся влево

            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);//определяем координаты по Х

     
                if (roundedX < 0) // Если достигло края перемещаем дочерний элемент вправо
                   children.position += new Vector3(12, 0, 0);
            }
            if (!ValidMove())// если достигли края, то останавливаемся
                transform.position -= new Vector3(-1, 0, 0);// / failTime;//transform.right  // остановка
            previosTime = Time.time; // отслеживаем реальное время
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (Time.time - previosTime > failTime / speed))//Движение вправо и  немного притормаживаем движение
        {
            transform.position += new Vector3(1, 0, 0);// / failTime;//transform.right  //двигаемся вправо 
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);//определяем координаты по Х

 
                if (roundedX == width  )// Если достигло края перемещаем дочерний элемент влево
                    children.position += new Vector3( -12, 0, 0);
            }
            if (!ValidMove())// если достигли края, то останавливаемся
                transform.position -= new Vector3(1, 0, 0);// / failTime;//transform.right  // остановка


            previosTime = Time.time; // отслеживаем реальное время
        }
        Mode1Mode2();

    }
    private void Mode1Mode2()
    {
        if (Input.GetKey(KeyCode.A) && (Time.time - previosTime > failTime / speed)) // поворачиваем влево и  немного притормаживаем движение
        {
            transform.RotateAround(transform.TransformPoint(rotatepoint), new Vector3(0, 0, 1), 90); // поворачиваем влево против часовой стрелки на 90 градусов
            previosTime = Time.time; // отслеживаем реальное время
        }

        if (Input.GetKey(KeyCode.D) && (Time.time - previosTime > failTime / speed)) // поворачиваем вправо и  немного притормаживаем движение
        {

            transform.RotateAround(transform.TransformPoint(rotatepoint), new Vector3(0, 0, 1), -90);// поворачиваем вправо по часовой стрелки на 90 градусов
            previosTime = Time.time; // отслеживаем реальное время
        }


        if (Time.time - previosTime > (Input.GetKey(KeyCode.DownArrow) ? failTime / speed : failTime)) //Движение вниз и если нажали кнопку ускоряемся, иначе идет по секундно
     
        {
            transform.position += new Vector3(0, -1, 0); // двигаемся вниз
            if (!ValidMove()) // проверяем достигли края или нет, если да то останавливаемся
            {
                transform.position -= new Vector3(0, -1, 0); // остановка

                if (transform.position.y < 18 )
                {
                     AddToGrid();// определяем где уже есть фигура
             
                    if (indexmode == 1)
                    {

                        CheckForLinesMode1();//Проверка собрана ли линия
                    }
                    else
                    {

                        CheckForLinesMode2();
                    }
                    this.enabled = false;
                    FindObjectOfType<SpawnerObject>().NewObject();//добавляем на экран новую фигуру
                }
                else if (transform.position.y >= 18 )
                { 
                    scriptText.indexwin = true;

                    scriptText.txtWinorBad("Вы проиграли!!!");
                   
                }
            }

            previosTime = Time.time; // отслеживаем реальное время
        }
    }
    #region Проверка и удаление заполненой строки
    /// <summary>
    /// Проходимся по сетке и смотрим есть ли собранная линия, если да то удаляем ее
    /// </summary>
    private void CheckForLinesMode1()
    {

        for (int i = height - 1; i >= 0; i--)
        {
   
            if (HasLine(i) )//Если такая линия найдена удаляем ее и смещаемся вниз
            {
                 DeleteLine(i);
                 RowDown(i);
            
                scriptText.AddScore(i * i);//В зависимости от того на какой строке была собрана строка столько очков и будет добавлено
            }
        }
    }
    /// <summary>
    /// Проходимся по сетке и смотрим есть ли собранная линия, если да то удаляем ее
    /// </summary>
    private void CheckForLinesMode2()
    {

        for (int i = height - 1; i >= 0; i -=2)
        {
            //Debug.Log(HasLine(i) + "  " +  HasLine(i + 1));
            if (HasLine(i) && HasLine(i - 1))//Если такая линия найдена удаляем ее и смещаемся вниз
            {
                DeleteLine(i);
                RowDown(i);

                DeleteLine(i  - 1);
                RowDown(i - 1);
                scriptText.AddScore((i + 1) * (i + 1));//В зависимости от того на какой строке была собрана строка столько очков и будет добавлено
            }
        }
    }
    /// <summary>
    /// Проверяем есть ли собранная линия
    /// </summary>
    /// <param name="i">Хранит значение точки по высоте</param>
    /// <returns>Возвращает true/false в зависимости от того есть ли пустые клетки в строке</returns>
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
          
            if (ScriptMainMenu.grid[j ,i] == null)//Если строка null значит есть пустые клетки
            {
      
                return false;
            }
        }
        //Если нет значит все клетки в линии заполнены
        return true;
    }
    /// <summary>
    /// Удалении собранной линии 
    /// </summary>
    /// <param name="i">Хранит значение точки по высоте</param>
    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(ScriptMainMenu.grid[j, i].gameObject);
            ScriptMainMenu.grid[j, i] = null;


        }

    }
    /// <summary>
    /// Проходим по сетке и смещаемся вниз
    /// </summary>
    /// <param name="i">Хранит значение точки по высоте</param>
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
    #region Добавляем текущую фигуру в дочерние элементы
    /// <summary>
    /// Добавляем в фигуру дочерний элемент
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
    #region Основная проверка
    /// <summary>
    /// Проверка по полю
    /// </summary>
    /// <returns>Возвращает true/false в зависимости от того достигла ли фигура края или нет, и есть ли новая фигура по текущим кооординатам или нет, если есть то возвращаем false</returns>
    bool ValidMove()
    {

  
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);//определяем координаты по Х
            int roundedY = Mathf.RoundToInt(children.transform.position.y);// определяем координаты по Y
            
   
            if (roundedX < 0 || roundedX >= width  || roundedY < 0 || roundedY >= height)//задаем границы за которые нельзя выходить
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
                
            if (ScriptMainMenu.grid[roundedX, roundedY] != null)// проверяем по новым координатам есть фигура или нет
            {
                return false;
            }
        }
        return true;
    }

    #endregion



}
