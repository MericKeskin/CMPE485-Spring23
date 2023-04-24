using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
   public FirstPersonMovement movement;
   public FirstPersonLook look;
   public TextMeshProUGUI status;
   public Button restart;
   public Button end;

   public void EndGame()
   {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
   }

   public void RestartGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void WinGame()
   {
        status.text = "Congratulations";
        movement.enabled = false;
        look.enabled = false;
        restart.gameObject.SetActive(true);
        end.gameObject.SetActive(true);
   }

   public void LoseGame()
   {
        status.text = "Game Over";
        movement.enabled = false;
        look.enabled = false;
        restart.gameObject.SetActive(true);
        end.gameObject.SetActive(true);
   }

   void Start()
   {
        restart.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
   }
}
