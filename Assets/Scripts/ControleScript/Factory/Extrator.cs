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
}
