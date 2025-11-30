using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SaveDataClass : MonoBehaviour {

    [SerializeField] public GameObject player;

    void Start(){
        if (player == null) player = GameObject.Find("XR Origin (XR Rig)"); 
    }

    public void SaveData() {
        PlayerPrefs.SetInt("Syringe", player.GetComponent<PlayerController>().hasSyringe);
        PlayerPrefs.SetInt("Beaker", player.GetComponent<PlayerController>().hasBeaker);
        PlayerPrefs.SetInt("Root", player.GetComponent<PlayerController>().hasRoot);
        PlayerPrefs.SetInt("Cure", player.GetComponent<PlayerController>().hasCure);
    }

    public void LoadData() {
        player.GetComponent<PlayerController>().hasSyringe = PlayerPrefs.GetInt("Syringe");
        player.GetComponent<PlayerController>().hasBeaker = PlayerPrefs.GetInt("Beaker");
        player.GetComponent<PlayerController>().hasRoot = PlayerPrefs.GetInt("Root");
        player.GetComponent<PlayerController>().hasCure = PlayerPrefs.GetInt("Cure");
    }

    public void DeleteData() {
        PlayerPrefs.DeleteAll();
    }
}