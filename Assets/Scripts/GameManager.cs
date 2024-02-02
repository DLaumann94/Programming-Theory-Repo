using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject selectedLauncher;
    [SerializeField] private GameObject catapult, swing, slingshot;
    private GameObject loadSlider;
    private int launcherID = 0;

    // Start is called before the first frame update
    void Start()
    {
        loadSlider = GameObject.Find("LoadSlider");
        SelectLauncher(launcherID);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLauncher(int selection) // ABSTRACTION
    {
        loadSlider.GetComponent<Slider>().interactable = true;
        loadSlider.GetComponent<Slider>().value = 0.0f;
        launcherID = selection;
        switch (launcherID)
        {
            case 0:
                ChangeLauncher(catapult); break;
            case 1:
                ChangeLauncher(swing); break;
            case 2:
                ChangeLauncher(slingshot); break;
        }
    }

    private void ChangeLauncher(GameObject newLauncher) // ABSTRACTION
    {
        if (selectedLauncher != null)
        {
            Destroy(selectedLauncher);
        }
        selectedLauncher = Instantiate(newLauncher);
    }

    public void ResetButtonPushed() // ABSTRACTION
    {
        SelectLauncher(launcherID);
    }

    public void LoadSliderChanged(float value) // ABSTRACTION
    {
        selectedLauncher.GetComponent<Launcher>().currentLoad = value;
        selectedLauncher.GetComponent<Launcher>().SetLoad();
    }

    public void ReleaseButtonPushed()
    {
        loadSlider.GetComponent<Slider>().interactable = false;
        selectedLauncher.GetComponent<Launcher>().LaunchProjectile();
    }
}
