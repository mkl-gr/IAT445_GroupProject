using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour
{
    public GameObject player;
    public List<int> contents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
}
