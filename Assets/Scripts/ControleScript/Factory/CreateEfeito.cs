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
                EfeitoAumentaMonstro efeitoAumentaMonstro = EfeitoAumentaMonstro.CreateInstance<EfeitoAumentaMonstro>();
                efeitoAumentaMonstro.Inicializa(titulo, new int[] {nivel, tesouro});
                return efeitoAumentaMonstro;

            case "EfeitoMorte":
                titulo = "morre";
                EfeitoMorte efeitoMorte = EfeitoMorte.CreateInstance<EfeitoMorte>();
                efeitoMorte.Inicializa(titulo, new int[] {});
                return efeitoMorte;

            case "EfeitoPerdeArmadura":
                titulo = "perde sua armadura";
                EfeitoPerdeArmadura efeitoPerdeArmadura = EfeitoPerdeArmadura.CreateInstance<EfeitoPerdeArmadura>();
                efeitoPerdeArmadura.Inicializa(titulo, new int[] {});
                return efeitoPerdeArmadura;

            case "EfeitoPerdeCalca":
                titulo = "perde sua calça";
                EfeitoPerdeCalca efeitoPerdeCalca = EfeitoPerdeCalca.CreateInstance<EfeitoPerdeCalca>();
                efeitoPerdeCalca.Inicializa(titulo, new int[] {});
                return efeitoPerdeCalca;

            case "EfeitoPerdeCalcado":
                titulo = "perde seu calçado";
                EfeitoPerdeCalcado efeitoPerdeCalcado = EfeitoPerdeCalcado.CreateInstance<EfeitoPerdeCalcado>();
                efeitoPerdeCalcado.Inicializa(titulo, new int[] {});
                return efeitoPerdeCalcado;

            case "EfeitoPerdeClasse":
                titulo = "perde sua classe";
                EfeitoPerdeClasse efeitoPerdeClasse = EfeitoPerdeClasse.CreateInstance<EfeitoPerdeClasse>();
                efeitoPerdeClasse.Inicializa(titulo, new int[] {});
                return efeitoPerdeClasse;

            case "EfeitoPerdeElmo":
                titulo = "perde seu elmo";
                EfeitoPerdeElmo efeitoPerdeElmo = EfeitoPerdeElmo.CreateInstance<EfeitoPerdeElmo>();
                efeitoPerdeElmo.Inicializa(titulo, new int[] {});
                return efeitoPerdeElmo;

            case "EfeitoPerdeItemGrande":
                titulo = "perde um item grande";
                EfeitoPerdeItemGrande efeitoPerdeItemGrande = EfeitoPerdeItemGrande.CreateInstance<EfeitoPerdeItemGrande>();    
                efeitoPerdeItemGrande.Inicializa(titulo, new int[] {});
                return efeitoPerdeItemGrande;

            case "EfeitoPerdeItemPequeno":
                titulo = "perde um item grande";
                EfeitoPerdeItemPequeno efeitoPerdeItemPequeno = EfeitoPerdeItemPequeno.CreateInstance<EfeitoPerdeItemPequeno>();
                efeitoPerdeItemPequeno.Inicializa(titulo, new int[] {});
                return efeitoPerdeItemPequeno;

            case "EfeitoPerdeNivel":
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"perde {nivel} níveis" : "perde 1 nível";
                EfeitoPerdeNivel efeitoPerdeNivel = EfeitoPerdeNivel.CreateInstance<EfeitoPerdeNivel>();
                efeitoPerdeNivel.Inicializa(titulo, new int[] {nivel});
                return efeitoPerdeNivel;

            case "EfeitoPerdeRaca":
                titulo = "perde sua raça e volta a ser humano";
                EfeitoPerdeRaça efeitoPerdeRaca = EfeitoPerdeRaça.CreateInstance<EfeitoPerdeRaça>();
                efeitoPerdeRaca.Inicializa(titulo, new int[] {});
                return efeitoPerdeRaca;

            case "EfeitoGanhaBonus":
                int bonus = int.Parse(atributos[0]);
                titulo = $"ganha um bônus de {bonus}";
                EfeitoGanhaBonus efeitoGanhaBonus = EfeitoGanhaBonus.CreateInstance<EfeitoGanhaBonus>();
                efeitoGanhaBonus.Inicializa(titulo, new int[] {bonus});
                return efeitoGanhaBonus;

            case "EfeitoGanhaNivel":
                nivel = int.Parse(atributos[0]);
                titulo = (nivel != 1) ? $"ganha {nivel} níveis" : "ganha 1 nível";
                EfeitoGanhaNivel efeitoGanhaNivel = EfeitoGanhaNivel.CreateInstance<EfeitoGanhaNivel>();
                efeitoGanhaNivel.Inicializa(titulo, new int[] {nivel});
                return efeitoGanhaNivel;

            default:
                return null;
        }
    }
}
