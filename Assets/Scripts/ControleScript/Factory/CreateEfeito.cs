using System;
using System.Collections.Generic;
using System.IO;

class CreateEfeito {

    static public Efeito Cria(string efeito, string descricao) {

        string[] atributos = descricao.Split(';');

        switch (efeito) {
            case "EfeitoAumentaMonstro":
                int nivel = int.Parse(atributos[0]);
                int tesouro = int.Parse(atributos[1]);
                string titulo = $"ajusta o nível do monstro em {nivel} e o tesouro em {tesouro}";
                return new EfeitoAumentaMonstro(titulo, new int[] {nivel, tesouro});

            case "EfeitoMorte":
                titulo = "morre";
                return new EfeitoMorte(titulo, new int[] {});

            case "EfeitoPerdeArmadura":
                titulo = "perde sua armadura";
                return new EfeitoPerdeArmadura(titulo, new int[] {});

            case "EfeitoPerdeCalca":
                titulo = "perde sua calça";
                return new EfeitoPerdeCalca(titulo, new int[] {});

            case "EfeitoPerdeCalcado":
                titulo = "perde seu calçado";
                return new EfeitoPerdeCalcado(titulo, new int[] {});

            case "EfeitoPerdeClasse":
                titulo = "perde sua classe";
                return new EfeitoPerdeClasse(titulo, new int[] {});

            case "EfeitoPerdeElmo":
                titulo = "perde seu elmo";
                return new EfeitoPerdeElmo(titulo, new int[] {});

            case "EfeitoPerdeItemGrande":
                titulo = "perde um item grande";
                return new EfeitoPerdeItemGrande(titulo, new int[] {});

            case "EfeitoPerdeItemPequeno":
                titulo = "perde um item grande";
                return new EfeitoPerdeItemPequeno(titulo, new int[] {});

            case "EfeitoPerdeNivel":
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"perde {nivel} níveis" : "perde 1 nível";
                return new EfeitoPerdeNivel(titulo, new int[]{nivel});

            case "EfeitoPerdeRaca":
                titulo = "perde sua raça e volta a ser humano";
                return new EfeitoPerdeRaça(titulo, new int[] {});

            case "EfeitoGanhaBonus":
                int bonus = int.Parse(atributos[0]);
                titulo = $"ganha um bônus de {bonus}";
                return new EfeitoGanhaBonus(titulo, new int[] {bonus});

            // EfeitoGanhaNivel
            default:
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"ganha {nivel} níveis" : "ganha 1 nível";
                return new EfeitoGanhaNivel(titulo, new int[] {nivel});
        }
    }
}
