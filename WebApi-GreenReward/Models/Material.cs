using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenReward.Server.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string NomeMaterial { get; set; }
        public float Valor { get; set; }
        public string UnidadeMedida { get; set; }

        public Material(string nomeMaterial, float valor, string unidadeMedida)
        {
            NomeMaterial = nomeMaterial;
            Valor = valor;
            UnidadeMedida = unidadeMedida;
        }
    }
}