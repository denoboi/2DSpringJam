using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
     [SerializeField] private float delay = 2f;
     private void OnEnable()
     {
          EventManager.OnPlayerDead.AddListener(Restart);
     }

     private void OnDisable()
     {
          EventManager.OnPlayerDead.RemoveListener(Restart);
     }
     
     private void Restart()
     {
          StartCoroutine(RestartCoroutine());
     }

     //wait for 2 seconds and restart the game
     private IEnumerator RestartCoroutine()
     {
          yield return new WaitForSeconds(delay);
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }

}
