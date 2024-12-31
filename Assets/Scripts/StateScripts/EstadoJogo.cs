using UnityEngine;

[CreateAssetMenu(fileName = "EstadoJogo", menuName = "Scriptable Objects/EstadoJogo")]
public abstract class EstadoJogo : ScriptableObject
{
    public abstract void IniciarEstado(Controle controle);
    public abstract void RunEstado(Controle controle);
    //Cada fim de Estado tem uma chamada a função do Troca de Estado
}
