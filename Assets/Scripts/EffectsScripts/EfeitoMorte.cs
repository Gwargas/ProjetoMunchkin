using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoMorte", menuName = "Scriptable Objects/EfeitoMorte")]
public class EfeitoMorte : Efeito
{
    public EfeitoMorte(string titulo, dynamic[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
