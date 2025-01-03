using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaNivel", menuName = "Scriptable Objects/EfeitoGanhaNivel")]
public class EfeitoGanhaNivel : Efeito
{
 
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Nivel += descricao[0];
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
