using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

 public static class BoughtBalls
{
    public static string balls;
    public static string fileName = Application.persistentDataPath + "/balls.txt";
    public static string basicBall = "0";

    public static void saveFile(int nb)
    {
        string number = nb.ToString();

        try
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, basicBall);   //0 for basic ball
            }

            balls = File.ReadAllText(fileName);
            if (!balls.Contains(number))
            {
                balls += number;
                File.WriteAllText(fileName, balls);
            }
        }

        catch (System.Exception e)
        {
            //Debug.Log(e);
        }
    }

    public static string loadFile()
    {
        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, basicBall);
            return basicBall;
        }
        else
        {
            balls = File.ReadAllText(fileName);
            return balls;
        }
    }
}
