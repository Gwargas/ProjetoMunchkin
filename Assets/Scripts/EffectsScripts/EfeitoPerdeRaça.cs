using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeRaça", menuName = "Scriptable Objects/EfeitoPerdeRaça")]
public class EfeitoPerdeRaça : Efeito
{
    public EfeitoPerdeRaça(string titulo, int[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply(Controle controle) {
        controle.JogadorAtual.Raca = "humano";
    }
}
