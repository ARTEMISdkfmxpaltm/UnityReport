using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenes : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "move";

    // ��ư ���� ����
    [SerializeField] private Button start;

    public void OnStartButtonClicked()
    {
        Debug.Log("Button Clicked!");
        // ���� ������ ��ȯ
        SceneManager.LoadScene(gameSceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (start != null)
        {
            start.onClick.AddListener(OnStartButtonClicked);
        }
        else
        {
            Debug.LogError("Start Button is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
