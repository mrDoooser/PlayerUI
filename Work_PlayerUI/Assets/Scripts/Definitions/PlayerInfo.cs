using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


[System.Serializable]
public class PlayerInfo
{
    public string PlayerNumber;
    public string PlayerName;
    public int TeamID;
    public string TeamName;
    public int InMainSquad;
    public string CoatchName;
    public int MainSquare;
    public int CoathID;
    public int PlayerRoleID;
    public string PlayerRole; // роль игрока (К - Капитан, ГК - голкипер)

    private int grade;

    public int Grade { get; set; } // оценка
    public int PlayTime { get; set; }// минут
    public int Goals { get; set; }// Голы 
    public int Penalty { get; set; }// Голы с пенальти
    public int Balls { get; set; }// Голевые пасы
    public bool RedCard { get; set; }// ЖК / КК
    public bool YellowCard { get; set; }// ЖК / КК

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        PlayerInfo newPlayer =  JsonUtility.FromJson<PlayerInfo>(jsonString);

        //newPlayer.Grade = Random.Range(10, 180);
        //newPlayer.Goals = Random.Range(0, 3);
        //newPlayer.Penalty = Random.Range(0, 15);
        //newPlayer.PlayTime = Random.Range(10, 180);
        //newPlayer.Balls = Random.Range(0, 5);
        //if (Random.Range(0, 2) > 0)
        //    newPlayer.RedCard = true;
        //if (Random.Range(0, 2) > 0)
        //    newPlayer.YellowCard = true;
        return newPlayer;
    }

}
