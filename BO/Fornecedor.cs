using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    class Fornecedor
    {
        int id;
        string nome;
        string nif;
        string morada;

        public Fornecedor(string nif)
        {
            this.nif = nif;
        }

        public Fornecedor(int id, string nome, string nif, string morada)
        {
            this.id = id;
            this.nome = nome;
            this.nif = nif;
            this.morada = morada;
        }

        public Fornecedor()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Nif { get => nif; set => nif = value; }
        public string Morada { get => morada; set => morada = value; }

        /// <summary>
        /// Verifica fornecedor com o mesmo NIF
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var fornecedor = obj as Fornecedor;
            return fornecedor != null &&
                   nif == fornecedor.nif;
        }
    }
}
