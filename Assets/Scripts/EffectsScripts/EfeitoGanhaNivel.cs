using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaNivel", menuName = "Scriptable Objects/EfeitoGanhaNivel")]
public class EfeitoGanhaNivel : Efeito
{
    public EfeitoGanhaNivel(string titulo, int[] descricao) : base(titulo, descricao) {}
    
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Nivel += descricao[0];
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
