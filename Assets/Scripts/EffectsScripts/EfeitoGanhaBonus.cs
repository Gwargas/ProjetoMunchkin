using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaBonus", menuName = "Scriptable Objects/EfeitoGanhaBonus")]
public class EfeitoGanhaBonus : Efeito
{
    public EfeitoGanhaBonus(string titulo, dynamic[] descricao) : base(titulo, descricao) {}
    
    public override void Apply() {
        //throw new System.NotImplementedException();
    }
}
