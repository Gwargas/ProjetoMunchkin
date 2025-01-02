using UnityEngine;

[CreateAssetMenu(fileName = "Efeito", menuName = "Scriptable Objects/Efeito")]
public abstract class Efeito : ScriptableObject {

    public string titulo;
    public dynamic[] descricao;

    public Efeito(string titulo, dynamic[] descricao) {
        this.titulo = titulo;
        this.descricao = descricao;
    }


    public abstract void Apply();


}
