using System;
using System.Collections.Generic;
using System.IO;

class CreateCartaPorta {

    static public CartaPorta Cria(string[] info) {

        // 0 - classe, 1 - imagem, 2 - efeito, 3 - descricao, 4 - nome, 5 - nivel, 6 - niveisAGanhar, 7 - recompensa
        string nome = info[5];
        string descricao = " ";
        Efeito efeito = CreateEfeito.Cria(info[2], info[3]);
        string imagem = info[1];

        switch (info[0]){
            case "CartaPorta":
                // toda carta porta que não for especialização é uma aumenta monstro
                // infelizmente CartaPorta é abstrata portando vira CartaMaldição
                descricao = $"Esta carta {efeito.titulo}.";
                return new CartaMaldição(nome, descricao, efeito, imagem);

            case "CartaMonstro":
                descricao = $"Monstro nível {info[5]}. Coisa ruim: você {efeito.titulo}.";
                int nivel = int.Parse(info[5]);
                int niveisAGanhar = int.Parse(info[6]);
                int recompensa = int.Parse(info[7]);
                return new CartaMonstro(nome, descricao, efeito, imagem, nivel, niveisAGanhar, recompensa);

            case "CartaMaldicao":
                descricao = $"Ai não! Você {efeito.titulo}.";
                return new CartaMaldição(nome, descricao, efeito, imagem);

            case "CartaClasse":
                return new CartaClasse(nome, descricao, efeito, imagem);

            // CartaRaca
            default:
                return new CartaRaca(nome, descricao, efeito, imagem);
        }   
    }
}
