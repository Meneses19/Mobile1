using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile1
{
    public class Jogo
    {
        private int id;
        private string titulo;
        private string publicadora;
        private string capa;
        private double preco;
        private int idpegi;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Publicadora
        {
            get { return publicadora; }
            set { publicadora = value; }
        }

        public string Capa
        {
            get { return capa; }
            set { capa = value; }
        }
        public string URIcapa
        {
            get { return "https://cstrix.com/teste/imagens/jogos/" + capa; }
        }
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public int IDpegi
        {
            get { return idpegi; }
            set { idpegi = value; }
        }

        public Jogo(int id, string titulo, string publicadora, string capa, double preco, int idpegi)
        {
            this.id = id;
            this.titulo = titulo;
            this.publicadora = publicadora;
            this.capa = capa;
            this.preco = preco;
            this.idpegi = idpegi;
        }
    }
}
