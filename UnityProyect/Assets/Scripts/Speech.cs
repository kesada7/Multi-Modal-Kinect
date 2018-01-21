using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject specialTrigger;
    UDP_RecoServer playerSpeech;
    bool hasSpoken = false;
    public GameObject greatsword;
    public GameObject Elven_Long_Bow;
    public GameObject barrel;
    bool barrel1 = true;
    public GameObject barrelSpawn1;
    public GameObject barrelSpawn2;

    void Start ()
    {
        playerSpeech = FindObjectOfType<UDP_RecoServer>();
        
        Debug.Log("UDP_RecoServer found: " + playerSpeech.name + " " + playerSpeech);
	}

    void Update()
    {
        //if (Sword == true)
        //{
        //    greatsword.SetActive(true);
        //    Elven_Long_Bow.SetActive(false);
        //}
        //else if (Sword == false)
        //{
        //    greatsword.SetActive(false);
        //    Elven_Long_Bow.SetActive(true);
        //}

        //Debug.Log("Update: " + playerSpeech);
        string command;
        command = playerSpeech.UDPGetPacket();
        if(command == "")
        {
            hasSpoken = false;
        }
        else
        {
            hasSpoken = true;
            Debug.Log("Unity" + command);
        }
        
        if(command == "spawn enemy")
        {
            Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
            playerSpeech.clearSpeech();
        }
        if(command == "spawn barrel")
        {
            if(barrel1 == true)
            {
                Instantiate(barrel, barrelSpawn1.transform.position, Quaternion.identity);
                barrel1 = false;
            }
            if(barrel1 == false)
            {
                Instantiate(barrel, barrelSpawn2.transform.position, Quaternion.identity);
                barrel1 = true;
            }
            playerSpeech.clearSpeech();
        }
        if(command == "special attack")
        {
            specialTrigger.SetActive(true);
            playerSpeech.clearSpeech();
        }
        if(command == "equip sword")
        {
            if (greatsword.activeInHierarchy == false)
            {
                Elven_Long_Bow.SetActive(false);
                greatsword.SetActive(true);
                playerSpeech.clearSpeech();
            }
        }
        if(command == "equip bow")
        {
            greatsword.SetActive(false);
            Elven_Long_Bow.SetActive(true);
            playerSpeech.clearSpeech();
            Debug.Log(greatsword.active);
            Debug.Log(Elven_Long_Bow.active);
        }
        //if (playerSpeech.UDPGetPacket() == "spawn")
        //{
        //    hasSpoken = true;
        //}
    }
    
}