using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamInfoPanelController : MonoBehaviour {

    [Space]
    [Header("Header fields:")]

    [SerializeField]
    private Text TeamName;
    [SerializeField]
    private Text CoatcherName;

    [Space]
    [Header("Player containers:")]
    [SerializeField]
    private GameObject PlayerInfoPanelPrefab;
    [SerializeField]
    private GameObject MainSquadPanel;
    [SerializeField]
    private GameObject SubstitutePlayersPanel;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateInfo(TeamInfo team)
    {
        CoatcherName.text = team.CoatchName;
        TeamName.text = team.TeamName;

        DestroyChilds(MainSquadPanel);

        DestroyChilds(SubstitutePlayersPanel);

        AddPlayersOnPanel(team.mainPlayers, MainSquadPanel);
        AddPlayersOnPanel(team.substitutePlayers, SubstitutePlayersPanel);
    }

    void AddPlayersOnPanel(ArrayList players, GameObject panel)
    {
        PlayerInfoPanelController panelController = null;
        GameObject newPanel = null;

        foreach (var player in players)
        {
            newPanel = null;
            panelController = null;

            newPanel = Instantiate<GameObject>(PlayerInfoPanelPrefab);
            if (newPanel != null)
            {
                newPanel.transform.SetParent(panel.transform);
                panelController = newPanel.GetComponent<PlayerInfoPanelController>();
                if(panelController!=null)
                {
                    panelController.UpdatePlayerInfo(player as PlayerInfo);
                }
            }
        }

    }

    void DestroyChilds(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }

    }
}
