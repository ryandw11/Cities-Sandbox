using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Signs : MonoBehaviour {

    public GameObject panel;
    public GameObject road;
    public GameObject buildings;
    public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;

    public SpawnObject spawnOBJ;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        road.SetActive(false);
        buildings.SetActive(false);
        signs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (!signs.activeSelf || !panel.activeSelf)
        {
            panel.SetActive(true);
            buildings.SetActive(false);
            road.SetActive(false);
            blocks.SetActive(false);
            signs.SetActive(true);
            terrain.SetActive(false);
        }
        else
        {
            panel.SetActive(false);
            signs.SetActive(false);
        }
    }


    public void OnSpeedLimit50Click()
    {
        spawnOBJ.resource = "SpeedLimit_Sign_50";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }

    public void OnNoLeftTurnClick()
    {
        spawnOBJ.resource = "NoTurn_Sign_Left";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }

    public void OnNoRightTurnClick()
    {
        spawnOBJ.resource = "NoTurn_Sign_Right";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }

    public void OnNoUTurnClick()
    {
        spawnOBJ.resource = "NoTurn_Sign_U";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnSchoolClick()
    {
        spawnOBJ.resource = "Info_Sign_School";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnNoParkingClick()
    {
        spawnOBJ.resource = "NoPark_Sign";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnBankClick()
    {
        spawnOBJ.resource = "Info_Sign_Bank";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnFblaClick()
    {
        spawnOBJ.resource = "Info_Sign_FBLA";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnCompetitionClick()
    {
        spawnOBJ.resource = "Info_Sign_Competition";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnHelpWantedClick()
    {
        spawnOBJ.resource = "Info_HelpWanted";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnMeetingClick()
    {
        spawnOBJ.resource = "Info_Sign_FBLA_Meeting";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnHostipalClick()
    {
        spawnOBJ.resource = "Info_Sign_Hostiple";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnInternshipClick()
    {
        spawnOBJ.resource = "Info_Sign_Internships";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnTechIncClick()
    {
        spawnOBJ.resource = "Info_Sign_TechInc";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
}
