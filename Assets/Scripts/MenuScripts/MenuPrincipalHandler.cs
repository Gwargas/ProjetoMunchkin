using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalHandler : MonoBehaviour
{
    [SerializeField] private string nomeDaSceneJogo;
    [SerializeField]private GameObject painelMenuInicial;
    [SerializeField]private GameObject painelMenuOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDaSceneJogo);
    }

    public void Opcoes()
    {
        painelMenuInicial.SetActive(false);
        painelMenuOpcoes.SetActive(true);
    }

    public void SairOpcoes()
    {
        painelMenuOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
