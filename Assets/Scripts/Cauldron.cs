using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour
{
    [SerializeField] public GameObject unloadingLocation;
    public GameObject player;
    public GameObject menu;
    public List<int> contentids;
    // public List<List<int>> recipes = new List<List<int>>();
    public List<ObjectScript> theContents;
    public List<GameObject> inCauldron;
    public AddText updateText;

    [System.Serializable]
    public class IntList
    {
        public List<int> nestedList;
        public GameObject product;
    }
    public List<IntList> recipes = new List<IntList>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("PP_Theme_06_Potion_002(Clone)"))
        {
            Debug.Log("Great Potion Cauldron Effect Triggered");
            Destroy(other);
            player.GetComponent<ChangeHeight>().i += player.GetComponent<ChangeHeight>().growTimer;
        }
    }

    public void AddToCauldron(int id) {
        contentids.Add(id);
    }

    public void AddToList(ObjectScript obj) {
        theContents.Add(obj);
    }

    public void CauldronInsert(GameObject obj) {
        inCauldron.Add(obj);
        updateText.PrintNames();
    }

    public bool CheckListForDuplicates(int id) {
        foreach (GameObject tempObject in inCauldron) {
            if (tempObject.GetComponent<ObjectScript>() != null)
                if (tempObject.GetComponent<ObjectScript>().GetObjectID() == id)
                    return true;
        } return false;
    }

    public void Cook(){
        int i = CheckListForRecipes();
        IntList relevantRecipe = recipes[i];
        if (i != 99) {
            GameObject theProduct = (GameObject)Instantiate(relevantRecipe.product, unloadingLocation.transform.position, unloadingLocation.transform.rotation);
        }
    }

    public int CheckListForRecipes() {
        for (int i = 0; i < recipes.Count; i++) {

            // Checks if the amount of ingredients needed for the recipe is 
            // the same as the amount of contents in the cauldron currently
            if (recipes[i].nestedList.Count == contentids.Count) {
                int matchingContents = 0;
                foreach (int currId in contentids) {

                    if (recipes[i].nestedList.Contains(currId)) matchingContents++;
                    else break;

                    if (matchingContents == contentids.Count) {
                        Debug.Log("Match found!");
                        return i;
                    }
                    
                }
            }
        }
        return 99;
    }

    public void UnloadContents() {
        if (inCauldron.Count > 0) {
            GameObject unloadedObject = inCauldron[inCauldron.Count-1];
            unloadedObject.SetActive(true);
            unloadedObject.transform.position = unloadingLocation.transform.position;
            inCauldron.Remove(inCauldron[inCauldron.Count-1]);
            contentids.Remove(inCauldron[inCauldron.Count-1].GetComponent<ObjectScript>().GetObjectID());
        }
        updateText.PrintNames();
    }
}
