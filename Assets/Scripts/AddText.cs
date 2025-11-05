using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AddText : MonoBehaviour
{
    [SerializeField] public TMP_Text contentText;
    [SerializeField] public Cauldron cauldron;

    void Start() {
    }

    public void PrintNames() {
        string formattedList = "Contents:\n";
        foreach (GameObject item in cauldron.inCauldron) {
            formattedList += item.GetComponent<ObjectScript>().GetObjectName() + "\n";
        }
        contentText.text = formattedList;
    }
}
