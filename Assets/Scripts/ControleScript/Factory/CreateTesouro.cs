using System;
using System.Collections.Generic;
using System.IO;

class CreateCartaTesouro {
    static public CartaTesouro Cria(string[] info) {

        // 0 - classe, 1 - imagem, 2 - efeito, 3 - descricao, 4 - nome, 5 - preco
        string nome = info[5];
        Efeito efeito = CreateEfeito.Cria(info[2], info[3]);
        string imagem = info[1];
        int preco = int.Parse(info[5]);

        switch (info[0]){
            case "CartaEquipamento":
                string descricao = $"Você {efeito.titulo} ao utilizar este equipamento.";
                string parteCorpo = info[3].Split(';')[1];
                int ehGrande = int.Parse(info[3].Split(';')[2]);
                return new CartaEquipamento(nome, descricao, efeito, imagem, preco, ehGrande, parteCorpo, "limitacaoRaca", "limitacaoClasse");

            //  CartaItem
            default:
                descricao = $"Você {efeito.titulo} ao utilizar este item.";
                return new CartaItem(nome, descricao, efeito, imagem, preco);
        }   
    }

}
