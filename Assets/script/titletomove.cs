using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenes : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "move";

    // 버튼 참조 변수
    [SerializeField] private Button start;

    public void OnStartButtonClicked()
    {
        Debug.Log("Button Clicked!");
        // 게임 씬으로 전환
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
