using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization;


public class ServerManagerHelper : MonoBehaviour {

    [Space]
    [Header("Server parameters:")]

    [SerializeField]
    private String _URI = "ws://localhost:8000";
    [SerializeField]
    private float TTR = 5;
    [SerializeField]
    private string ComandDevider = "::";

    private WebSocket _webSocket;

    private static ServerManagerHelper serverManager;

    public static ServerManagerHelper ServerManager 
    {
        get
        {
            return serverManager;
        }
    }

    private bool connectionActive;

    public bool IsConnectionActive { get { return connectionActive; }  }

    private bool IncomingData;
    private bool WaitingData;
    private string InputMsg;
    private Queue<string> Commands;

    //public delegate void ServerDataReceived(Object data);

    public event Action<MatchInfo> OnMatchInfoChanged;
    public event Action<TeamInfo> OnTeam1Changed;
    public event Action<TeamInfo> OnTeam2Changed;

    

    // Use this for initialization
    void Start () {
        serverManager = this;
        Commands = new Queue<string>();
        //OnMatchInfoReceived;
        SetConnection();
    }
	
	// Update is called once per frame
	void Update () {

        //SetConnection();
	}


    private void SetConnection()
    {
        connectionActive = false;

        Uri uri = new Uri(_URI);

        try
        {
            _webSocket = new WebSocket(uri);
            print("Web socket created! _webSocket = " + _webSocket);
        }
        catch (Exception e)
        {
            print(e.ToString());
        }


        if (_webSocket != null)
        {
            StartCoroutine(_webSocket.Connect());
            connectionActive = true;
            StartCoroutine(ReceiveData());
        }
        else
        { 
            print("_webSocket not initialized! ");
        }
    }

    void AddCommand(String command)
    {
        if (_webSocket == null)
            return;

        print("Add command to queue : " + command);

        Commands.Enqueue(command);

        SendCommand();
    }

    void SendCommand()
    {
        if (WaitingData)
            return;

        if (Commands.Count == 0)
            return;

        WaitingData = true;
        string currCommand = Commands.Dequeue();
        print("Send command to queue : " + currCommand);
        _webSocket.SendString(currCommand);
    }


    IEnumerator ReceiveData()
    {
        print("Check to receive data...");
        if (_webSocket == null)
        {
            yield return 0;
        }
        print("Ready to receive data...");
        while (true)
        {
            yield return new WaitForSeconds(TTR);
            
            string inputMsg = _webSocket.RecvString();
            if (inputMsg != null && inputMsg.Length > 0)
            {
                IncomingData = true;
                InputMsg += inputMsg;
            }
            else
            {
                if(IncomingData)
                {
                    IncomingData = false;
                    WaitingData = false;
                    SendCommand();
                    ParceData(InputMsg);
                    InputMsg = "";
                }
            }
        }
    }

    void CloseConnection()
    {
        //yield return new WaitForSeconds(5);

        if (_webSocket != null)
        {
            print("Close connection");
            _webSocket.Close();
        }
        //else
        //    yield return 0;
    }


    public void GetMatchInfo(int matchID = 1)
    {
        if (!connectionActive)
            return;

        String command = "{ \"CommandName\": \"GetMatchInfo\", \"MatchID\": " + matchID + " }";

        AddCommand(command);
    }


    public void GetMatchInfoResult(string result)
    {
        MatchInfo matchInfo = new MatchInfo();
        print(result);
        if (result[0] == '[')
            result = DeleteIncorrectSymbols(result);

        matchInfo = MatchInfo.CreateFromJSON(result);//JsonUtility.FromJson<MatchInfo>(str2);

        if(OnMatchInfoChanged!=null)
            OnMatchInfoChanged.Invoke(matchInfo);
        
    }


    public void GetTeamsSolutionsOnMatch(int matchID = 1)
    {
        if (!connectionActive)
            return;

        String command = "{ \"CommandName\": \"GetTeamsSolutionsOnMatch\", \"MatchID\": " + matchID + " }";

        AddCommand(command);
    }

    public void GetTeamsSolutionsOnMatchResult(string result)
    {
        //print("Teams: ");
        //print(result);

        if (result[0] == '[')
            result = DeleteIncorrectSymbols(result);

        TeamInfo Team1 = null;
        TeamInfo Team2 = null;

        TeamInfo.CreateTeams(result, out Team1, out Team2, "\n");

        //print("Team1 - " + Team1.TeamName);
        //print("mainPlayers:");
        //foreach (PlayerInfo item in Team1.mainPlayers)
        //{
        //    print(item.TeamName + " | " + item.PlayerName);
        //}
        //print("substitutePlayers:");
        //foreach (PlayerInfo item in Team1.substitutePlayers)
        //{
        //    print(item.TeamName + " | " + item.PlayerName);
        //}
        //print("-----------------------------");


        //print("Team2 - " + Team2.TeamName);
        //print("mainPlayers:");
        //foreach (PlayerInfo item in Team2.mainPlayers)
        //{
        //    print(item.TeamName + " | " + item.PlayerName);
        //}
        //print("substitutePlayers:");
        //foreach (PlayerInfo item in Team2.substitutePlayers)
        //{
        //    print(item.TeamName + " | " + item.PlayerName);
        //}
        //print("-----------------------------");


        if (OnTeam1Changed != null)
            OnTeam1Changed.Invoke(Team1);

        if (OnTeam2Changed != null)
            OnTeam2Changed.Invoke(Team2);

        //PlayerInfo[] playerInfos = JsonHelper.FromJson<PlayerInfo>(result);

        //print("playerInfos.Length: " + playerInfos.Length);
    }

    void ParceData(string incomingData)
    {
        string commandResult;
        string command = GetCommandName(incomingData, out commandResult);

        switch (command)
        {
            case "GetMatchInfo":
                {
                    GetMatchInfoResult(commandResult);
                }
                break;
            case "GetTeamsSolutionsOnMatch":
                {
                    GetTeamsSolutionsOnMatchResult(commandResult);
                }
                break;
            default:
                print("Incorrect command!");
                break;
        }

        print("Incoming result for command: " + command);
    }

    string DeleteIncorrectSymbols(string inputString)
    {
        char[] str = inputString.ToCharArray();
        for (int i = 0; i < inputString.Length; i++)
        {
            str[i] = ' ';
        }
        inputString.CopyTo(1, str, 0, inputString.Length - 2);

        return new string(str);
    }

    string GetCommandName(string incomingData, out string commandResult)
    {
        string result = "";
        commandResult = "";

        if (!incomingData.Contains(ComandDevider))
            return result;

        char[] spliter = ComandDevider.ToCharArray();
        
        string[] results = incomingData.Split(spliter);

        if (results.Length > 1)
        {
            commandResult = results[1];
            return results[0];
        }
        else
            return result;
    }


}
