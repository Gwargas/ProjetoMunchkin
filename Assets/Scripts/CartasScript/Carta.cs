using UnityEngine;

public abstract class Carta : ScriptableObject
{
    [SerializeField] private string nome;
    [SerializeField] private string descricao;
    [SerializeField] private string cartaPath;
    [SerializeField] private Efeito efeito;
    
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

    public string CartaPath
    {
        get => cartaPath;
        set => cartaPath = value;
    }

    public Efeito Efeito
    {
        get => efeito;
        set => efeito = value;
    }

    public abstract void EfeitoCompra(Controle controle);
}
