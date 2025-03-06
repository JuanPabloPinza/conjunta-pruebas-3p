using System.Data.SqlClient;
using TDDTestingMVC.Data;

namespace TDDTestingMVC.Models
{
    public class PedidoDataAccessLayer
    {
        // Actualiza el connectionString según tu configuración
        string connectionString = "Data Source=DESKTOP-U6VF3S2; Initial Catalog=dbproductos; User ID=sa; Password=password";

        public List<Pedido> getAllPedido()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                    listaPedidos.Add(pedido);
                }
                con.Close();
            }
            return listaPedidos;
        }

        public void addPedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Pedido getPedidoById(int pedidoID)
        {
            Pedido pedido = new Pedido();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                }
                con.Close();
            }
            return pedido;
        }

        public void updatePedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedido.PedidoID);
                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void deletePedido(int pedidoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
