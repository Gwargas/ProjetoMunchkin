using UnityEngine;

[CreateAssetMenu(fileName = "CartaEquipamento", menuName = "Scriptable Objects/CartaEquipamento")]
public class CartaEquipamento : CartaTesouro
{
    [SerializeField] private int ehGrande;
    [SerializeField] private string parteCorpo;

    // construtor
    public void Inicializa(string nome, string descricao, Efeito efeito, string imagem, int preco, int ehGrande, string parteCorpo) {
        this.Nome = nome;
        this.Descricao = descricao;
        this.Efeito = efeito;
        this.CartaPath = imagem;
        this.Preco = preco;
        this.ehGrande = ehGrande;
        this.parteCorpo = parteCorpo;
    }

    public override void EfeitoCompra(Controle controle) {}

    // a gente tirou carta com restrição
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
