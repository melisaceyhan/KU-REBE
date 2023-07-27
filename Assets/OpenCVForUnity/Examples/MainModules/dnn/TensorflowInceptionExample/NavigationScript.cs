using UnityEngine;
using UnityEngine.SceneManagement;
public class NavigationScript : MonoBehaviour
{
    public bool CanSearchObject1 = false;
    public bool CanSearchObject2 = false;
    public bool CanSearchObject3 = false;
    public bool CanSearchObject4 = false;
    public bool CanSearchObject5 = false;
    public bool CanSearchObject6 = false;
    public bool CanSearchObject7 = false;

    public GameObject MissionsMenu;
    public GameObject returnMenuButton;
    public GameObject Frame;
    public GameObject Score;
    public GameObject YourScore;
    public GameObject objectFoundScreen;
    public GameObject returnMainMenuButton;

    public void DeactivateBackground()
    {
        MissionsMenu.SetActive(false);
        returnMenuButton.SetActive(true);
        Frame.SetActive(true);
        Score.SetActive(false);
        YourScore.SetActive(false);
        returnMainMenuButton.SetActive(false);

    }

    public void ActivateBackground()
    {
        MissionsMenu.SetActive(true);
        returnMenuButton.SetActive(false);
        Frame.SetActive(false);
        Score.SetActive(true);
        YourScore.SetActive(true);
        objectFoundScreen.SetActive(false);
        returnMainMenuButton.SetActive(true);

    }

    public void SearchingObject1()
    {
        CanSearchObject1 = true;
    }

    public void SearchingObject2()
    {
        CanSearchObject2 = true;
    }

    public void SearchingObject3()
    {
        CanSearchObject3 = true;
    }

    public void SearchingObject4()
    {
        CanSearchObject4 = true;
    }

    public void SearchingObject5()
    {
        CanSearchObject5 = true;
    }

    public void SearchingObject6()
    {   
        CanSearchObject6 = true;
    }

    public void SearchingObject7()
    {
        CanSearchObject7 = true;
    }

    public void SearchingImpossible()
    {
        CanSearchObject1 = false;
        CanSearchObject2 = false;
        CanSearchObject3 = false;
        CanSearchObject4 = false;
        CanSearchObject5 = false;
        CanSearchObject6 = false;
        CanSearchObject7 = false;
    }

    public void ReturnMainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }

}

