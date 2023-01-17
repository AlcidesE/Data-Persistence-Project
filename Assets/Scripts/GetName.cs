using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetName : MonoBehaviour
{
    public static GetName Instance;

    public string inputName;
    public TextMeshProUGUI inputField;

    private void Awake()
    {
        if (Instance != null) //destroy duplicate object when returning to main menu (i.e. data persistence)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; //allows you to access MainManager object from any other script
        DontDestroyOnLoad(gameObject);
    }

    public void ReadStringInput(string s) //used to get user name from the TextMeshPro input field in the start menu
    {
        inputName = inputField.text;
        Debug.Log(inputName);
    }
}
