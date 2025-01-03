using UnityEngine;

[CreateAssetMenu(fileName = "Efeito", menuName = "Scriptable Objects/Efeito")]
public abstract class Efeito : ScriptableObject {

    public string titulo;
    public int[] descricao;

    public void Inicializa(string titulo, int[] descricao) {
        this.titulo = titulo;
        this.descricao = descricao;
    }

    public abstract void Apply(Controle controle);
    public abstract void Revert(Controle controle);
}
