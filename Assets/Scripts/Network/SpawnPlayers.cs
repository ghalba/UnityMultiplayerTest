using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {


        int playerIndex = PhotonNetwork.LocalPlayer.ActorNumber % spawnPoints.Length;
        Transform spawnPoint = spawnPoints[playerIndex];

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
