using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isPlaying = false;
    [SerializeField] private Button _npcButton;
    [SerializeField] private Button _playerButton;
    [SerializeField] private RaqueteController _player2;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        Time.timeScale = 0f;
        _npcButton.onClick.AddListener(SetNPCGame);
        _playerButton.onClick.AddListener(SetPlayerGame);
        _menu.SetActive(true);
    }

    public void SetNPCGame()
    {
        _player2.automatico = true;
        Time.timeScale = 1f;
        _menu.SetActive(false);
    }

    public void SetPlayerGame()
    {
        _player2.automatico = false;
        Time.timeScale = 1f;
        _menu.SetActive(false);
    }
}
