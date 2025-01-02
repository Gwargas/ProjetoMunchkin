using UnityEngine;

[CreateAssetMenu(fileName = "CartaEquipamento", menuName = "Scriptable Objects/CartaEquipamento")]
public class CartaEquipamento : CartaTesouro
{
    [SerializeField] private int ehGrande;
    [SerializeField] private string parteCorpo;
    [SerializeField] private string limitacaoRaca; 
    [SerializeField] private string limitacaoClasse;

    public CartaEquipamento(string nome, string descricao, Efeito efeito, string imagem, int preco, int ehGrande, string parteCorpo, string limitacaoRaca, string limitacaoClasse) : base(nome, descricao, efeito, imagem, preco)
    {
        this.ehGrande = ehGrande;
        this.parteCorpo = parteCorpo;
        this.limitacaoRaca = limitacaoRaca;
        this.limitacaoClasse = limitacaoClasse;
    }

    public override void EfeitoCompra(Controle controle)
    {
        
    }

    public bool condicaoUso(){
        throw new System.NotImplementedException();
        // (Note: David) Lógica de uso 
    } 

    public string ParteCorpo {
        get => parteCorpo;
        set => parteCorpo = value;
    }

    public int EhGrande {
        get => ehGrande;
        set => ehGrande = value;
    }
}
