using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeNivel", menuName = "Scriptable Objects/EfeitoPerdeNivel")]
public class EfeitoPerdeNivel : Efeito
{
    public EfeitoPerdeNivel(string titulo, int[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Nivel -= descricao[0];
    }
}
