using UnityEngine;

[CreateAssetMenu(fileName = "CartaMonstro", menuName = "Scriptable Objects/CartaMonstro")]
public class CartaMonstro : CartaPorta
{
    [SerializeField] private int nivel;
    [SerializeField] private int niveisAGanhar;
    [SerializeField] private int recompensa;

    // construtor 
    public void Inicializa(string nome, string descricao, Efeito efeito, string imagem, int nivel, int niveisAGanhar, int recompensa)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.Efeito = efeito;
        this.CartaPath = imagem;
        this.nivel = nivel;
        this.niveisAGanhar = niveisAGanhar;
        this.recompensa = recompensa;
    }

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public int NiveisAGanhar
    {
        get => niveisAGanhar;
        set => niveisAGanhar = value;
    }

    public int Recompensa
    {
        get => recompensa;
        set => recompensa = value;
    }


    public override void EfeitoCompra(Controle controle)
    {
        controle.TrocaEstado(new EstadoCombate());
    }
}
