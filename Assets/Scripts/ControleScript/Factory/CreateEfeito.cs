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
