using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoMorte", menuName = "Scriptable Objects/EfeitoMorte")]
public class EfeitoMorte : Efeito
{
    public EfeitoMorte(string titulo, int[] descricao) : base(titulo, descricao) {}
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Morto = true;
    }

    public override CartaMonstro Apply(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override CartaMonstro Revert(CartaMonstro carta)
    {
        throw new System.NotImplementedException();
    }

    public override void Revert(Controle controle)
    {
        throw new System.NotImplementedException();
    }
}
