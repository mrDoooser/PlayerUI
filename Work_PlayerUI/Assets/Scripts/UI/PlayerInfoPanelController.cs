using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanelController : MonoBehaviour {

    private PlayerInfo CurrentPlayerInfo;

    [Space]
    [Header("Common visualisation:")]
    [SerializeField]
    private Text NumberText;

    [SerializeField]
    private Text NameText;

    [Space]
    [Header("Stats visualisation:")]
    [SerializeField]
    private GameObject StatsPanel;

    [SerializeField]
    private GameObject StatsBigPrefab;

    [SerializeField]
    private GameObject StatsSmallPrefab;

    [Header("Stats icons:")]
    [SerializeField]
    private Sprite GoalsImage;
    [SerializeField]
    private Sprite PenaltyImage;
    [SerializeField]
    private Sprite BallsImage;
    [SerializeField]
    private Sprite RedCardImage;
    [SerializeField]
    private Sprite YellowCardImage;
    [SerializeField]
    private Sprite YellowAndRedCardsImage;

    [SerializeField]
    private int MaxStatsInPanel = 6;


    // Use this for initialization
    void Start () {
        CurrentPlayerInfo = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePlayerInfo(PlayerInfo playerInfo)
    {
        CurrentPlayerInfo = playerInfo;

        NameText.text = CurrentPlayerInfo.PlayerName;
        NumberText.text = CurrentPlayerInfo.PlayerNumber;

        UpdatePlayerStats();
    }

    void UpdatePlayerStats()
    {
        //StatsPanel
        foreach (Transform child in StatsPanel.transform) Destroy(child.gameObject);

        //if (CurrentPlayerInfo.PlayerRole != null && CurrentPlayerInfo.PlayerRole != "")
        AddStat(CurrentPlayerInfo.PlayerRole, null, false);

        if (CurrentPlayerInfo.Grade != 0)
            AddStat(CurrentPlayerInfo.Grade.ToString(), null, false);
        else
            AddStat(null, null, false);

        if (CurrentPlayerInfo.PlayTime != 0)
            AddStat(CurrentPlayerInfo.PlayTime.ToString(), null, false);
        else
            AddStat(null, null, false);

        if (CurrentPlayerInfo.Goals != 0)
            if (CurrentPlayerInfo.Goals > 1)
                AddStat(CurrentPlayerInfo.Goals.ToString(), GoalsImage);
            else
                AddStat(null, GoalsImage);
        else
            AddStat(null, null);

        if (CurrentPlayerInfo.Penalty != 0)
            if (CurrentPlayerInfo.Penalty > 1)
                AddStat(CurrentPlayerInfo.Penalty.ToString(), PenaltyImage);
            else
                AddStat(null, GoalsImage);
        else
            AddStat(null, null);


        if (CurrentPlayerInfo.Balls != 0)
            if (CurrentPlayerInfo.Balls > 1)
                AddStat(CurrentPlayerInfo.Balls.ToString(), BallsImage);
            else
                AddStat(null, GoalsImage);
        else
            AddStat(null, null);

        if (CurrentPlayerInfo.RedCard)
            if (CurrentPlayerInfo.YellowCard)
                AddStat(null, YellowAndRedCardsImage);
            else
                AddStat(null, RedCardImage);
        else
            if (CurrentPlayerInfo.YellowCard)
                AddStat(null, YellowCardImage);
            else
                AddStat(null, null);

    }

    void AddStat(string text = null, Sprite image = null, bool IsSmall = true)
    {
        
        GameObject stat = Instantiate<GameObject>(IsSmall? StatsSmallPrefab: StatsBigPrefab);
        stat.transform.SetParent(StatsPanel.transform);
        PlayerStatsInfoController statInfo = stat.GetComponent<PlayerStatsInfoController>();
        statInfo.SetText(text);
        statInfo.SetImage(image);
    }
}
