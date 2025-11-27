using UnityEngine;
using UnityEngine;
using TMPro;
using System.Collections;


public class TextCycling : MonoBehaviour
{

    public TextMeshProUGUI textObject;
    public string[] textsTutorial;
    public string[] textsCave;
    public string[] textsLab;
    public string[] textsWasteland;
    public string[] textsFinalCutscene;
    public float durationOfEachMessage = 3f;

    private int currentIndex = 0;

    void Start()
    {
        if (textObject == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
            enabled = false;
            return;
        }
    }

    public void textCycle(int cycleID) {
        if (cycleID == 1) StartCoroutine(CycleTextTutorial());
        if (cycleID == 2) StartCoroutine(CycleTextCave());
        if (cycleID == 3) StartCoroutine(CycleTextLab());
        if (cycleID == 4) StartCoroutine(CycleTextWasteland());
        if (cycleID == 5) StartCoroutine(CycleTextFinalCutscene());
    }

    IEnumerator CycleTextTutorial()
    {
        while (true)
        {
            textObject.text = textsTutorial[currentIndex];
            currentIndex = (currentIndex + 1) % textsTutorial.Length;
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextCave()
    {
        while (true)
        {
            textObject.text = textsCave[currentIndex];
            currentIndex = (currentIndex + 1) % textsCave.Length;
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextLab()
    {
        while (true)
        {
            textObject.text = textsLab[currentIndex];
            currentIndex = (currentIndex + 1) % textsLab.Length;
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextWasteland()
    {
        while (true)
        {
            textObject.text = textsWasteland[currentIndex];
            currentIndex = (currentIndex + 1) % textsWasteland.Length;
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextFinalCutscene()
    {
        while (true)
        {
            textObject.text = textsFinalCutscene[currentIndex];
            currentIndex = (currentIndex + 1) % textsFinalCutscene.Length;
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }
}
