using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject selectedLauncher;
    [SerializeField] private GameObject catapult, swing, slingshot;
    private GameObject loadSlider;

    // Start is called before the first frame update
    void Start()
    {
        loadSlider = GameObject.Find("LoadSlider");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLauncher(int selection)
    {
        switch (selection)
        {
            case 0:
                SetLauncher(catapult); break;
            case 1:
                SetLauncher(swing); break;
            case 2:
                SetLauncher(slingshot); break;
        }
    }

    private void SetLauncher(GameObject newLauncher)
    {
        if (selectedLauncher != null)
        {
            selectedLauncher.SetActive(false);
        }
        selectedLauncher = newLauncher;
        selectedLauncher.SetActive(true);
    }

    public void ResetButtonPushed()
    {
        selectedLauncher.GetComponent<Launcher>().ResetLauncher();
        loadSlider.GetComponent<Slider>().value = 0.0f;
    }
}
