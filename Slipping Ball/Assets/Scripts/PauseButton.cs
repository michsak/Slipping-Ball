using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject gameObject;
    bool param = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        param = true;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        param = false;
    }

    public bool IsButtonClicked()
    {
        return param;
    }
}
