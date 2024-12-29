// Script para colocar menu em um Game 3D, ou 2D na Unity:

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManage : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Carrega a cena de índice 1
    }

    public void ExitGames()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Sai do jogo em build
#endif
    }
}