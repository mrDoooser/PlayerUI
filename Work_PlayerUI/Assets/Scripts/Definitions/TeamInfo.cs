using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


[System.Serializable]
public class TeamInfo
{

    public string TeamName;
    public int TeamID;
    public string CoatchName;
    public int CoathID;
    public ArrayList mainPlayers;
    public ArrayList substitutePlayers;

    protected TeamInfo()
    {
        mainPlayers = new ArrayList();
        substitutePlayers = new ArrayList();
    }

    public static TeamInfo CreateTeamInfo()
    {
        return new TeamInfo();
    }

    public static void CreateTeams(string jsonString, out TeamInfo Team1, out TeamInfo Team2, string spliterString = "/n")
    {
         ArrayList palyersJson = JsonHelper.DevideString(jsonString);
 
        Team1 = TeamInfo.CreateTeamInfo();
        Team2 = TeamInfo.CreateTeamInfo();

        TeamInfo CurrTeam = null;

        foreach (string item in palyersJson)
        {
            PlayerInfo player = PlayerInfo.CreateFromJSON(item);
            if(CurrTeam == null)
            {
                CurrTeam = Team1;
                CurrTeam.TeamID = player.TeamID;
                CurrTeam.TeamName = player.TeamName;
                CurrTeam.CoatchName = player.CoatchName;
                CurrTeam.CoathID = player.CoathID;
            } else if (CurrTeam.TeamID != player.TeamID)
            {
                if (CurrTeam == Team1)
                    CurrTeam = Team2;
                else
                    CurrTeam = Team1;

                if(CurrTeam.TeamID == 0)
                { 
                    CurrTeam.TeamID = player.TeamID;
                    CurrTeam.TeamName = player.TeamName;
                    CurrTeam.CoatchName = player.CoatchName;
                    CurrTeam.CoathID = player.CoathID;
                }
            }

            if (player.InMainSquad == 0)
                CurrTeam.substitutePlayers.Add(player);
            else
                CurrTeam.mainPlayers.Add(player);
         }
    }

}
