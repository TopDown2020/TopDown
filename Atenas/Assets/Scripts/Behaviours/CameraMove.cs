using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject hud;
    public GameObject hudPrefab;
    public Transform startPosition;
    public GameObject gameMenu;
    public GameObject gameMenuPrefab;

    public void Awake()
    {
        hud = GameObject.Find("HUD");
        if (hud == null)
        {
            hud = Instantiate(hudPrefab);
            hud.name = hudPrefab.name;
        }

        gameMenu = GameObject.Find("GameMenu");
        if (gameMenu == null)
        {
            gameMenu = Instantiate(gameMenuPrefab);
            gameMenu.name = gameMenuPrefab.name;
            gameMenu.SetActive(false);
        }
        
        player = GameObject.Find("Player");
        if (player == null)
        {
            player = Instantiate(playerPrefab, startPosition.position, Quaternion.identity);
            player.name = playerPrefab.name;
        }
        else
            player.transform.position = startPosition.position;
    }

    public void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x,
                                             player.transform.position.y,
                                             transform.position.z);

            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    gameMenu.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    gameMenu.SetActive(false);
                }
            }
        }
        else
        {
            Time.timeScale = 0;
            gameMenu.SetActive(true);
            gameMenu.transform.GetChild(0).gameObject.SetActive(false);
            gameMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void End()
    {
        Time.timeScale = 0;
        gameMenu.SetActive(true);
        gameMenu.transform.GetChild(0).gameObject.SetActive(false);
        gameMenu.transform.GetChild(2).gameObject.SetActive(true);
    }
}
