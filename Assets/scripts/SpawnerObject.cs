using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnerObject : MonoBehaviour
{
    /// <summary>
    /// Переменная хранящая фигуры
    /// </summary>
    public GameObject[] objspawn;
    /// <summary>
    /// Режим игры
    /// </summary>
    public int modes = 1;


    // Start is called before the first frame update
    void Start()
    {

        modes = PlayerPrefs.GetInt("modeSelections", 1);
        NewObject();
          
    }

    /// <summary>
    /// Создание нового объекта
    /// </summary>
    public void NewObject()
    {   

        Resrandom(modes);

    }

    /// <summary>
    /// Указание процента выпадения фигуры
    /// </summary>
    /// <param name="mods">Указывает какой режим выбран</param>
    private void Resrandom(int mods)
    {

        int rand = Random.Range(0, 100);

        if (rand >= 0 && rand <= 10)
        {
            Instantiate(objspawn[0], transform.position, Quaternion.identity);
        }

        if (rand > 10 && rand <= 25)
        {
            Instantiate(objspawn[1], transform.position, Quaternion.identity);
        }

        if (rand > 25 && rand <= 40)
        {
            Instantiate(objspawn[2], transform.position, Quaternion.identity);
        }

        if (rand > 40 && rand <= 55)
        {
            Instantiate(objspawn[3], transform.position, Quaternion.identity);
        }

        if (rand > 55 && rand <= 70)
        {
            Instantiate(objspawn[4], transform.position, Quaternion.identity);
        }

        if (rand > 70 && rand <= 80)
        {
            Instantiate(objspawn[5], transform.position, Quaternion.identity);
        }

        if (modes == 1)
        {

            if (rand > 80 && rand <= 100)
            {
                Instantiate(objspawn[6], transform.position, Quaternion.identity);
            }

        }
        else
        {

            if (rand > 80 && rand <= 85)
            {
                Instantiate(objspawn[6], transform.position, Quaternion.identity);
            }

            if (rand > 85 && rand <= 90)
            {
                Instantiate(objspawn[7], transform.position, Quaternion.identity);
            }

            if (rand > 90 && rand <= 95)
            {
                Instantiate(objspawn[8], transform.position, Quaternion.identity);
            }

            if (rand > 95 && rand <= 100)
            {
                Instantiate(objspawn[9], transform.position, Quaternion.identity);
            }

        }

    }

}
