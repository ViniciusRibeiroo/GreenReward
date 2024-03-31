using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenReward.Server.Models
{
    public class Historico
    {
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        // public Material Material { get; set; }
        public float Peso { get; set; }
        public float ValorTotal { get; set; }

        public Historico(int idMaterial, float peso, float valorTotal)
        {
            IdMaterial = idMaterial;
            Peso = peso;
            ValorTotal = valorTotal;
        }
    }
}