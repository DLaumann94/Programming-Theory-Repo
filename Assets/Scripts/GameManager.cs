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

    public void SelectLauncher(int selection)
    {
        loadSlider.GetComponent<Slider>().interactable = true;
        loadSlider.GetComponent<Slider>().value = 0.0f;
        launcherID = selection;
        switch (launcherID)
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
            Destroy(selectedLauncher);
        }
        selectedLauncher = Instantiate(newLauncher);
    }

    public void ResetButtonPushed()
    {
        SelectLauncher(launcherID);
    }

    public void LoadSliderChanged(float value)
    {
        selectedLauncher.GetComponent<Launcher>().SetLoad(value);
    }

    public void ReleaseButtonPushed()
    {
        loadSlider.GetComponent<Slider>().interactable = false;
        selectedLauncher.GetComponent<Launcher>().LaunchProjectile();
    }
}
