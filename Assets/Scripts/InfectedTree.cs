using UnityEngine;
using System.Collections.Generic;

public class InfectedTree : MonoBehaviour
{
    
    // public GameObject player;

    //add objs to the array (add elements for however many infected objs there are)
    //drag objs from hierarchy, preferably group them first into parent groups so you dont have to drag each individual obj
    [SerializeField] public GameObject[] infectedObjs;

    [SerializeField] public GameObject cleanWater; //uncomment this if you want to make the water blue instead of orange when cured
    [SerializeField] public GameObject infectedWater;
    [SerializeField] public string cureName;

    void Start(){
        // if (player == null) player = GameObject.Find("XR Origin (XR Rig)");
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with main infection source");

        // add conditions to check if player has made cure then interacted with the tree
        if (other.gameObject.name == cureName) //change condition if not using projectile to cure
        {
            disableInfected();
        }
    }

    public void disableInfected()
    {

        cleanWater.SetActive(true); //uncomment this if you want to make the water blue instead of orange when cured
        infectedWater.SetActive(false);

        foreach (GameObject obj in infectedObjs)
        {
            obj.SetActive(false);
        }
    }
}