using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour
{
    public GameObject player;
    public GameObject menu;
    public List<int> contents;
    public List<ObjectScript> theContents;
    public List<GameObject> inCauldron;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Great Potion"))
        {
            Debug.Log("Great Potion Cauldron Effect Triggered");
            Destroy(other);
            player.GetComponent<ChangeHeight>().i += player.GetComponent<ChangeHeight>().growTimer;
        }
    }

    public void AddToCauldron(int id) {
        contents.Add(id);
    }

    public void AddToList(ObjectScript obj) {
        theContents.Add(obj);
    }

    public void CauldronInsert(GameObject obj) {
        inCauldron.Add(obj);
    }

    public bool CheckListForDuplicates(int id) {
        foreach (GameObject tempObject in inCauldron) {
            if (tempObject.GetComponent<ObjectScript>() != null)
                if (tempObject.GetComponent<ObjectScript>().GetObjectID() == id)
                    return true;
        } return false;
    }

    public void UnloadContents(int id) {
        foreach (GameObject tempObject in inCauldron) {
            tempObject.SetActive(true);
        }
        inCauldron.Clear();
    }
}
