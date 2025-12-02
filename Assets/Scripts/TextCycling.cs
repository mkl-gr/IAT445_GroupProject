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
    private Coroutine myRunningCoroutine;

    void Start() {
        if (textObject == null) {
            Debug.LogError("TextMeshProUGUI component not assigned!");
            enabled = false;
            return;
        }
    }

    void Update() {
        if (Input.GetKey(KeyCode.P)) {
            textObject.text = "";
            currentIndex = 0;
            StopCoroutine(myRunningCoroutine);
        }
    }

    public void textCycle(int cycleID) {
        if (cycleID == 1) myRunningCoroutine = StartCoroutine(CycleTextTutorial());
        if (cycleID == 2) myRunningCoroutine = StartCoroutine(CycleTextCave());
        if (cycleID == 3) myRunningCoroutine = StartCoroutine(CycleTextLab());
        if (cycleID == 4) myRunningCoroutine = StartCoroutine(CycleTextWasteland());
        if (cycleID == 5) myRunningCoroutine = StartCoroutine(CycleTextFinalCutscene());
    }

    public void textCycleThenDestroy(int cycleID) {
        if (cycleID == 1) myRunningCoroutine = StartCoroutine(CycleTextTutorial());
        if (cycleID == 2) myRunningCoroutine = StartCoroutine(CycleTextCave());
        if (cycleID == 3) myRunningCoroutine = StartCoroutine(CycleTextLab());
        if (cycleID == 4) myRunningCoroutine = StartCoroutine(CycleTextWasteland());
        if (cycleID == 5) myRunningCoroutine = StartCoroutine(CycleTextFinalCutscene());
        Destroy(gameObject);
    }

    IEnumerator CycleTextTutorial()
    {
        while (true)
        {
            textObject.text = textsTutorial[currentIndex];
            currentIndex = (currentIndex + 1) % textsTutorial.Length;
            if (currentIndex == textsTutorial.Length-1) {
                textObject.text = "";
                currentIndex = 0;
                StopCoroutine(myRunningCoroutine);
            }
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextCave()
    {
        while (true)
        {
            textObject.text = textsCave[currentIndex];
            currentIndex = (currentIndex + 1) % textsCave.Length;
            if (currentIndex == textsCave.Length-1) {
                textObject.text = "";
                currentIndex = 0;
                StopCoroutine(myRunningCoroutine);
            }
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextLab()
    {
        while (true)
        {
            textObject.text = textsLab[currentIndex];
            currentIndex = (currentIndex + 1) % textsLab.Length;
            if (currentIndex == textsLab.Length-1) { 
                textObject.text = "";
                currentIndex = 0;
                StopCoroutine(myRunningCoroutine);
            }
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextWasteland()
    {
        while (true)
        {
            textObject.text = textsWasteland[currentIndex];
            currentIndex = (currentIndex + 1) % textsWasteland.Length;
            if (currentIndex == textsWasteland.Length-1) {
                textObject.text = "";
                currentIndex = 0;
                StopCoroutine(myRunningCoroutine);
            }
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }

    IEnumerator CycleTextFinalCutscene()
    {
        while (true)
        {
            textObject.text = textsFinalCutscene[currentIndex];
            currentIndex = (currentIndex + 1) % textsFinalCutscene.Length;
            if (currentIndex == textsFinalCutscene.Length-1) { 
                textObject.text = "";
                currentIndex = 0;
                StopCoroutine(myRunningCoroutine);
            }
            yield return new WaitForSeconds(durationOfEachMessage);
        }
    }
}
