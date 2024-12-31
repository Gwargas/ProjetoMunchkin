using System;
using System.Collections.Generic;
using System.IO;

class Extrator {

    // extrai informacoes de um arquivo csv
    static List<string[]> CsvToList(string nomeArquivo) {
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
    }

    static CartaPorta ExtraiCartaPorta(string[] info) {

        // classe, imagem, efeito, descricao, nome, nivel, niveisAGanhar, recompensa
        switch (info[0]){
            case "CartaClasse":
                break;
            case "CartaMaldicao":
                break;
            case "CartaMonstro":
                break;
            case "CartaPorta":
                break;
            case "CartaRaca":
                break;
            default:
        }   
    }

    static Efeito ExtraiEfeito(string efeito, string[] descricao) {
        switch (efeito) {
            case "EfeitoAumentaMonstro":
                return new EfeitoAumentaMonstro(descricao);

            case "EfeitoMorte":
                return new EfeitoMorte([]);

            case "EfeitoPerdeArmadura":
                return new EfeitoPerdeArmadura(descricao);

            case "EfeitoPerdeCalca":
                return new EfeitoPerdeCalca(descricao);

            case "EfeitoPerdeCalcado":
                return new EfeitoPerdeCalcado(descricao);

            case "EfeitoPerdeClasse":
                return new EfeitoPerdeClasse([]);

            case "EfeitoPerdeElmo":
                return new EfeitoPerdeElmo(descricao);

            case "EfeitoPerdeItemGrande":
                return new EfeitoPerdeItemGrande(descricao);

            case "EfeitoPerdeItemPequeno":
                return new EfeitoPerdeItemPequeno(descricao);

            case "EfeitoPerdeNivel":
                return new EfeitoPerdeNivel(descricao);

            case "EfeitoPerdeRaca":
                return new EfeitoPerdeRaça(descricao);
        }
    }
}
