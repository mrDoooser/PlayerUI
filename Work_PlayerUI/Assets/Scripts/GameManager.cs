using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
   

	// Use this for initialization
	void Start () {

        StartCoroutine(TestServer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TestServer()
    {
        //while(true)
        //{
            yield return new WaitForSeconds(0.2f);
            print("Send test command: GetMatchInfo(1)");
            ServerManagerHelper.ServerManager.GetMatchInfo(1);

            yield return new WaitForSeconds(0.2f);
            print("Send test command: GetTeamsSolutionsOnMatch(1)");
            ServerManagerHelper.ServerManager.GetTeamsSolutionsOnMatch(1);
        //}
    }
}
