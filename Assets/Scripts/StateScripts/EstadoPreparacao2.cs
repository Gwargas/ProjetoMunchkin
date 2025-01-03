using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EstadoPreparacao2", menuName = "Scriptable Objects/EstadoPreparacao2")]
public class EstadoPreparacao2 : EstadoJogo
{
    private Button botaoCartaPorta;
    private bool encrenca = false;
    public override void IniciarEstado(Controle controle)
    {
        botaoCartaPorta = GameObject.Find("BotaoCartaPorta")?.GetComponent<Button>();
        botaoCartaPorta.onClick.RemoveAllListeners();
        botaoCartaPorta.onClick.AddListener(() => {
            Debug.Log("Botão Clicado");
            Debug.Log("Escolheu Saquear a Sala");
            controle.TrocaEstado(EstadoSaquear.CreateInstance<EstadoSaquear>());
        });
    }

    public override void RunEstado(Controle controle)
    {
        //Encrenca fica true quando ocorre a movimentação das cartas
        if(encrenca){
            Debug.Log("Escolheu arrumar Encrenca");
            controle.TrocaEstado(EstadoEncrenca.CreateInstance<EstadoEncrenca>());
            // Remover carta da mão do jogador e remover condicional (Estado Encrenca)   
        }
    }
}
