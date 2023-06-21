using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField iField;
    // Start is called before the first frame update
    void Start()
    {
        if (Data.Instance != null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterName()
    {
        string name = iField.text;
        Data.Instance.playerName = name;
        print(name);
    }
}
