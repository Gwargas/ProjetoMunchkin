using UnityEngine;

public abstract class Carta : ScriptableObject
{
    [SerializeField] private string nome;
    [SerializeField] private string descricao;
    [SerializeField] private Efeito efeito;
    [SerializeField] private string cartaPath;

    //  construtor
    public Carta(string nome, string descricao, Efeito efeito, string cartaPath) {
        this.nome = nome;
        this.descricao = descricao;
        this.efeito = efeito;
        this.cartaPath = cartaPath;
    }

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

    public abstract void EfeitoCompra(Controle controle);
}
