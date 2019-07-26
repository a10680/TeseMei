using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    class Campos
    {
        int id;
        string nome;
        int posX;
        int posY;
        int largura;
        int altura;
        int tipoDocumento_id;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public int Largura { get => largura; set => largura = value; }
        public int Altura { get => altura; set => altura = value; }
        public int TipoDocumento_id { get => tipoDocumento_id; set => tipoDocumento_id = value; }

        public Campos(int id, string nome, int posX, int posY, int largura, int altura, int tipoDocumento_id)
        {
            this.id = id;
            this.nome = nome;
            this.posX = posX;
            this.posY = posY;
            this.largura = largura;
            this.altura = altura;
            this.tipoDocumento_id = tipoDocumento_id;
        }

        public Campos()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
