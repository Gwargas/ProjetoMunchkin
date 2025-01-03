using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoMorte", menuName = "Scriptable Objects/EfeitoMorte")]
public class EfeitoMorte : Efeito
{
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Morto = true;
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
