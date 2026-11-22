using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Globalization;
using MySqlConnector;

namespace Mobile1
{
    static class Dados
    {
        //============================================================================LIGACAO=========================================================================================
        public static string conString = "SERVER=cstrix.com; DATABASE=esffpap_exemplo; UID=esffpap_exemplo; PWD=exemplopap13*;persistsecurityinfo=True;SslMode=none;";
        public static MySqlConnection conn = null;
        private static void AbrirLigacao()
        {
            try
            {
                conn = new MySqlConnection(conString);
                conn.Open();
                //MessageBox.Show("Ligação estabelecida com sucesso");
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Erro na ligação" + ex);
            }
        }

        private static void FecharLigacao()
        {
            try
            {

                conn.Close();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Erro na ligação" + ex);
            }
        }

        /// <summary>
        /// Método que retorna todos os Jogos da bd
        /// </summary>
        /// <returns>lista de Jogos</returns>
        public static List<Jogo> Jogos()
        {
            AbrirLigacao();

            List<Jogo> listaJogos = new List<Jogo>();

            var querysql = "SELECT * FROM Jogo";

            MySqlDataReader leitor = null;
            MySqlCommand cmd = new MySqlCommand(querysql, conn);

            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Jogo novoJogo = new Jogo(Convert.ToInt32(leitor["ID"]), Convert.ToString(leitor["Titulo"]), Convert.ToString(leitor["Publicadora"]), Convert.ToString(leitor["Capa"]), Convert.ToDouble(leitor["Preco"]), Convert.ToInt32(leitor["IDpegi"]));
                listaJogos.Add(novoJogo);
            }
            FecharLigacao();
            return listaJogos;
        }
        //public static List<Pegi> Pegis() 
        //{

        //    AbrirLigacao();
        //    List<Pegi> listaPegi = new List<Pegi>();
        //    var querysql = "SELECT * FROM Pegi";

        //    MySqlDataReader leitor = null;
        //    MySqlCommand cmd = new MySqlCommand(querysql, conn);

        //    leitor = cmd.ExecuteReader();
        //    while (leitor.Read())
        //    {
        //        Pegi novopegi = new Pegi(Convert.ToInt32(leitor["ID"]), Convert.ToString(leitor["Icone"]), Convert.ToString(leitor["Nome"]), Convert.ToString(leitor["Descricao"]));
        //        listaPegi.Add(novopegi);
        //    }
        //FecharLigacao();
        //    return listaPegi;
        //}

        public static int nfavoritos(int id)
        {
            AbrirLigacao();
            var querysql = "SELECT COUNT(IDJogo) as fav FROM Favoritos WHERE IDJogo = @idjogo";

            MySqlDataReader leitor = null;
            MySqlCommand cmd = new MySqlCommand(querysql, conn);
            cmd.Parameters.AddWithValue("@idjogo", id);
            leitor = cmd.ExecuteReader();
            leitor.Read();

            int fav = Convert.ToInt32(leitor["fav"]);
            FecharLigacao();
            return fav;
        }
        public static void AtualizaJogo(int id, string titulo, string publicadora, int idpegi, double preco)
        {
            AbrirLigacao();


            var querysql = "UPDATE Jogo SET titulo = @titulo, publicadora = @publicadora, preco = @preco, idpegi = @IDpegi WHERE ID=@ID; ";


            MySqlCommand cmd = new MySqlCommand(querysql, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@publicadora", publicadora);
            cmd.Parameters.AddWithValue("@preco", preco);
            cmd.Parameters.AddWithValue("@IDpegi", idpegi);

            cmd.ExecuteNonQuery();
            FecharLigacao();
        }

        public static List<Jogo> Jogos(string titulo)
        {
            AbrirLigacao();

            List<Jogo> listaJogos = new List<Jogo>();

            var querysql = "SELECT * FROM Jogo where titulo LIKE @titf";

            MySqlDataReader leitor = null;
            MySqlCommand cmd = new MySqlCommand(querysql, conn);
            cmd.Parameters.AddWithValue("@titf", "%" + titulo + "%");
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Jogo novoJogo = new Jogo(Convert.ToInt32(leitor["ID"]), Convert.ToString(leitor["Titulo"]), Convert.ToString(leitor["Publicadora"]), Convert.ToString(leitor["Capa"]), Convert.ToDouble(leitor["Preco"]), Convert.ToInt32(leitor["IDpegi"]));
                listaJogos.Add(novoJogo);
            }
            FecharLigacao();
            return listaJogos;
        }

        //public static List<Jogo> Jogos(Pegi pegi)
        //{
        //    AbrirLigacao();

        //    List<Jogo> listaJogos = new List<Jogo>();

        //    var querysql = "SELECT * FROM Jogo where IDPegi = @peg";

        //    MySqlDataReader leitor = null;
        //    MySqlCommand cmd = new MySqlCommand(querysql, conn);
        //    cmd.Parameters.AddWithValue("@peg", pegi.ID);

        //    leitor = cmd.ExecuteReader();
        //    while (leitor.Read())
        //    {
        //        Jogo novoJogo = new Jogo(Convert.ToInt32(leitor["ID"]), Convert.ToString(leitor["Titulo"]), Convert.ToString(leitor["Publicadora"]), Convert.ToString(leitor["Capa"]), Convert.ToDouble(leitor["Preco"]), Convert.ToInt32(leitor["IDpegi"]));
        //        listaJogos.Add(novoJogo);
        //    }
        //    FecharLigacao();
        //    return listaJogos;
        //}

        //public static List<Jogo> Jogos(string titf, Pegi pegi)
        //{
        //    AbrirLigacao();

        //    List<Jogo> listaJogos = new List<Jogo>();

        //    var querysql = "SELECT * FROM Jogo where titulo LIKE @titf AND IDPegi = @peg";

        //    MySqlDataReader leitor = null;
        //    MySqlCommand cmd = new MySqlCommand(querysql, conn);
        //    cmd.Parameters.AddWithValue("@titf", "%" + titf + "%");
        //    cmd.Parameters.AddWithValue("@peg", pegi.ID);

        //    leitor = cmd.ExecuteReader();
        //    while (leitor.Read())
        //    {
        //        Jogo novoJogo = new Jogo(Convert.ToInt32(leitor["ID"]), Convert.ToString(leitor["Titulo"]), Convert.ToString(leitor["Publicadora"]), Convert.ToString(leitor["Capa"]), Convert.ToDouble(leitor["Preco"]), Convert.ToInt32(leitor["IDpegi"]));
        //        listaJogos.Add(novoJogo);
        //    }
        //    FecharLigacao();
        //    return listaJogos;
        //}
    }
}
