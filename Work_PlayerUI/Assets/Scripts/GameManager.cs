using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private MatchInfo matchInfo;

    public MatchInfo MatchInfo
    {
        get { return matchInfo; }
        set { matchInfo = value; }
    }

    private TeamInfo team1Info;

    public TeamInfo Team1Info
    {
        get { return team1Info; }
        set { team1Info = value; }
    }

    private TeamInfo team2Info;

    public TeamInfo Team2Info
    {
        get { return team2Info; }
        set { team2Info = value; }
    }




    // Use this for initialization
    void Start () {
        StartCoroutine(InitializeLinks());
        StartCoroutine(TestServer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator InitializeLinks()
    {
        yield return new WaitForSeconds(0.2f);
        ServerManagerHelper.ServerManager.OnMatchInfoChanged += UpdateMatchInfo;
        ServerManagerHelper.ServerManager.OnTeam1Changed += UpdateTeam1;
        ServerManagerHelper.ServerManager.OnTeam2Changed += UpdateTeam2;
    }

    public void UpdateMatchInfo(MatchInfo matchInfo)
    {
        MatchInfo = matchInfo;

        //print(MatchInfo.StadiumName);
    }

    public void UpdateTeam1(TeamInfo team)
    {
        Team1Info = team;
        //print(team1Info.TeamName);
    }

    public void UpdateTeam2(TeamInfo team)
    {
        Team2Info = team;
        //print(team2Info.TeamName);
    }

    IEnumerator TestServer()
    {
        //while(true)
        //{
            yield return new WaitForSeconds(0.5f);
            print("Send test command: GetMatchInfo(1)");
            ServerManagerHelper.ServerManager.GetMatchInfo(1);

            yield return new WaitForSeconds(0.2f);
            print("Send test command: GetTeamsSolutionsOnMatch(1)");
            ServerManagerHelper.ServerManager.GetTeamsSolutionsOnMatch(1);
        //}
    }
}
