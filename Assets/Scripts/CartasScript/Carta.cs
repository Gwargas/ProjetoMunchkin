using UnityEngine;

public abstract class Carta : ScriptableObject
{
    [SerializeField] private string nome;
    [SerializeField] private string descricao;

    public string Nome
    {
        get => nome;
        set => nome = value;
    }

    public string Descricao
    {
        get => descricao;
        set => descricao = value;
    }

    public abstract void EfeitoCompra();
}
