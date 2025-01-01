using System;
using System.Collections.Generic;
using System.IO;

class Extrator {

    // extrai informacoes de um arquivo csv
    static public List<string[]> CsvToList(string nomeArquivo) {
        // listas para armazenar as informações
        List<string[]> informacoes = new List<string[]>();

        // ler o arquivo linha por linha
        foreach (var linha in File.ReadLines(nomeArquivo)) {
            // ignorar cabeçalho
            if (linha.StartsWith("classe")) continue;

            // dividir a linha em colunas
            string[] dados = linha.Split(',');

            // adicionar os dados à lista
            informacoes.Add(dados);
        }

        return informacoes;
    }

    static public CartaPorta CriaCartaPorta(string[] info) {

        // 0 - classe, 1 - imagem, 2 - efeito, 3 - descricao, 4 - nome, 5 - nivel, 6 - niveisAGanhar, 7 - recompensa
        string nome = info[5];
        string descricao = " ";
        Efeito efeito = CriaEfeito(info[2], info[3]);
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

    static public CartaTesouro CriaCartaTesouro(string[] info) {

        // 0 - classe, 1 - imagem, 2 - efeito, 3 - descricao, 4 - nome, 5 - preco
        string nome = info[5];
        Efeito efeito = CriaEfeito(info[2], info[3]);
        string imagem = info[1];
        int preco = int.Parse(info[5]);

        switch (info[0]){
            case "CartaEquipamento":
                string descricao = $"Você ganha {efeito.titulo} ao utilizar este equipamento.";
                int bonus = (int)efeito.descricao[0];
                int ehGrande = int.Parse(info[3].Split(';')[2]);
                string parteCorpo = info[3].Split(';')[1];
                return new CartaEquipamento(nome, descricao, efeito, imagem, preco, bonus, ehGrande, parteCorpo, "limitacaoRaca", "limitacaoClasse");

            //  CartaItem
            default:
                descricao = $"Você ganha {efeito.titulo} ao utilizar este item.";
                bonus = (int)efeito.descricao[0];
                return new CartaItem(nome, descricao, efeito, imagem, preco, bonus);
        }   
    }

    static Efeito CriaEfeito(string efeito, string descricao) {

        string[] atributos = descricao.Split(';');

        switch (efeito) {
            case "EfeitoAumentaMonstro":
                int nivel = int.Parse(atributos[0]);
                int tesouro = int.Parse(atributos[1]);
                string titulo = $"ajusta o nível do monstro em {nivel} e o tesouro em {tesouro}";
                return new EfeitoAumentaMonstro(titulo, new object[] {nivel, tesouro});

            case "EfeitoMorte":
                titulo = "morre";
                return new EfeitoMorte(titulo, new object[] {});

            case "EfeitoPerdeArmadura":
                titulo = "perde sua armadura";
                return new EfeitoPerdeArmadura(titulo, new object[] {});

            case "EfeitoPerdeCalca":
                titulo = "perde sua calça";
                return new EfeitoPerdeCalca(titulo, new object[] {});

            case "EfeitoPerdeCalcado":
                titulo = "perde seu calçado";
                return new EfeitoPerdeCalcado(titulo, new object[] {});

            case "EfeitoPerdeClasse":
                titulo = "perde sua classe";
                return new EfeitoPerdeClasse(titulo, new object[] {});

            case "EfeitoPerdeElmo":
                titulo = "perde seu elmo";
                return new EfeitoPerdeElmo(titulo, new object[] {});

            case "EfeitoPerdeItemGrande":
                titulo = "perde um item grande";
                return new EfeitoPerdeItemGrande(titulo, new object[] {});

            case "EfeitoPerdeItemPequeno":
                titulo = "perde um item grande";
                return new EfeitoPerdeItemPequeno(titulo, new object[] {});

            case "EfeitoPerdeNivel":
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"perde {nivel} níveis" : "perde 1 nível";
                return new EfeitoPerdeNivel(titulo, new object[]{nivel});

            case "EfeitoPerdeRaca":
                titulo = "perde sua raça e volta a ser humano";
                return new EfeitoPerdeRaça(titulo, new object[] {});

            case "EfeitoGanhaBonus":
                int bonus = int.Parse(atributos[0]);
                titulo = $"ganha um bônus de {bonus}";
                return new EfeitoGanhaBonus(titulo, new object[] {bonus});

            // EfeitoGanhaNivel
            default:
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"ganha {nivel} níveis" : "ganha 1 nível";
                return new EfeitoGanhaNivel(titulo, new object[] {titulo});
        }
    }
}
