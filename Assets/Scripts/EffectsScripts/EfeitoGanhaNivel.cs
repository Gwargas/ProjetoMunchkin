using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoGanhaNivel", menuName = "Scriptable Objects/EfeitoGanhaNivel")]
public class EfeitoGanhaNivel : Efeito
{
    public EfeitoGanhaNivel(string titulo, dynamic[] descricao) : base(titulo, descricao) {}
    
    public override void Apply() {
        //throw new System.NotImplementedException();
    }
}
