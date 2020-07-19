using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{

    public GameObject[] menuPages;
    public GameObject mainMenu;

    public void GotoPage(GameObject x)
    {
        if(menuPages.Length > 0)
        {
            mainMenu.SetActive(false);
            foreach(GameObject eachPage in menuPages)
            {
                if(eachPage == x)
                {
                    eachPage.SetActive(true);
                }
                else
                {
                    eachPage.SetActive(false);
                }
            }
        }
    }
}
