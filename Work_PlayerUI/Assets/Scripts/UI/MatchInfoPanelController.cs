using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchInfoPanelController : MonoBehaviour {

    [Space]
    [Header("Header fields:")]

    [SerializeField]
    private Text LeagueName;
    [SerializeField]
    private Text StadiumName;
    [SerializeField]
    private Text TourName;
    [SerializeField]
    private Text ViewersCount;

    [Space]
    [Header("Teams:")]
    [SerializeField]
    private TeamInfoPanelController Team1Controller;
    [SerializeField]
    private TeamInfoPanelController Team2Controller;


    // Use this for initialization
    void Start () {

        StartCoroutine(InitializeLinks());


    }

    IEnumerator InitializeLinks()
    {
        yield return new WaitForSeconds(1);
        ServerManagerHelper.ServerManager.OnMatchInfoChanged += UpdateHeader;
        ServerManagerHelper.ServerManager.OnTeam1Changed += UpdateTeam1;
        ServerManagerHelper.ServerManager.OnTeam2Changed += UpdateTeam2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHeader(MatchInfo matchInfo)
    {
        if (matchInfo!=null)
        {
            LeagueName.text = matchInfo.LeagueName;
            StadiumName.text = matchInfo.StadiumName;
            TourName.text = matchInfo.TourName;
            ViewersCount.text = matchInfo.Viewers.ToString();
        }
    }

    public void UpdateTeam1(TeamInfo team)
    {
        Team1Controller.UpdateInfo(team);
    }

    public void UpdateTeam2(TeamInfo team)
    {
        Team2Controller.UpdateInfo(team);
    }

}
