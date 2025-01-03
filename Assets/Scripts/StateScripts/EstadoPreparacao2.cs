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
            controle.TrocaEstado(EstadoSaquear.CreateInstance<EstadoSaquear>());
        });
    }

    public override void RunEstado(Controle controle)
    {
        //Encrenca fica true quando ocorre a movimentacao das cartas
        if(encrenca){
            controle.TrocaEstado(new EstadoEncrenca());
        }
    }
}
