using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaNivel", menuName = "Scriptable Objects/EfeitoGanhaNivel")]
public class EfeitoGanhaNivel : Efeito
{
 
    public override void Apply(Controle controle) {
        if(controle.JogadorAtual.Nivel+ descricao[0] < 10)
        {
            controle.JogadorAtual.Nivel += descricao[0];
            Debug.Log("Nivel teste");
        } 
        Debug.Log("Impossível chegar ao nível 10 sem matar um monstro");    
        
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
