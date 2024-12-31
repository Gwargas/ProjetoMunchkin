using UnityEngine;

[CreateAssetMenu(fileName = "Efeito", menuName = "Scriptable Objects/Efeito")]
public abstract class Efeito : ScriptableObject {

    string[] descricao;

    public Efeito(string[] descricao) {
        this.descricao = descricao;
    }


    public abstract void Apply();


}
