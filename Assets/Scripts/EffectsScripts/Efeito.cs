using UnityEngine;

[CreateAssetMenu(fileName = "Efeito", menuName = "Scriptable Objects/Efeito")]
public abstract class Efeito : ScriptableObject {

    string titulo;
    object[] descricao;

    public Efeito(string titulo, object[] descricao) {
        this.titulo = titulo;
        this.descricao = descricao;
    }


    public abstract void Apply();


}
