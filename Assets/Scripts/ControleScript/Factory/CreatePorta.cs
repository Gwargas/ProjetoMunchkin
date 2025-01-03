using System;
using System.Collections.Generic;
using System.IO;

class CreateCartaPorta {

    static public CartaPorta Cria(string[] info) {

        // 0 - classe, 1 - imagem, 2 - efeito, 3 - descricao, 4 - nome, 5 - nivel, 6 - niveisAGanhar, 7 - recompensa
        string nome = info[4];
        string descricao;
        Efeito efeito = CreateEfeito.Cria(info[2], info[3]);
        string imagem = info[1];

        switch (info[0]){
            case "CartaPorta":
                // CartaPorta é abstrata portando vira CartaMaldição
                descricao = $"Com esta carta voce {efeito.titulo}.";
                CartaMaldição cartaPorta = CartaMaldição.CreateInstance<CartaMaldição>();
                cartaPorta.Inicializa(nome, descricao, efeito, imagem);
                return cartaPorta;

            case "CartaMonstro":
                descricao = $"Monstro nivel {info[5]}. Coisa ruim: voce {efeito.titulo}.";
                int nivel = int.Parse(info[5]);
                int niveisAGanhar = int.Parse(info[6]);
                int recompensa = int.Parse(info[7]);
                CartaMonstro cartaMonstro = CartaMonstro.CreateInstance<CartaMonstro>();
                cartaMonstro.Inicializa(nome, descricao, efeito, imagem, nivel, niveisAGanhar, recompensa);
                return cartaMonstro;

            case "CartaMaldicao":
                descricao = $"Ai meu deus! Voce {efeito.titulo}.";
                CartaMaldição cartaMaldicao = CartaMaldição.CreateInstance<CartaMaldição>();
                cartaMaldicao.Inicializa(nome, descricao, efeito, imagem);
                return cartaMaldicao;

            case "CartaClasse":
                descricao = $"Agora voce pode ser um nobre {nome}.";
                CartaClasse cartaClasse = CartaClasse.CreateInstance<CartaClasse>();
                cartaClasse.Inicializa(nome, descricao, efeito, imagem);
                return cartaClasse;

            // CartaRaca
            default:
                descricao = $"Pra que ser humano? Seja um {nome}.";
                CartaRaca cartaRaca = CartaRaca.CreateInstance<CartaRaca>();
                cartaRaca.Inicializa(nome, descricao, efeito, imagem);
                return cartaRaca;
        }   
    }
}
