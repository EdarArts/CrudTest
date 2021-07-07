using CrudTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CrudTest.Context
{
    public class CrudTest_DAL
    {
        string connectionString = "Data Source = DESKTOP-6VVSSAO ; Initial Catalog=CrudTestDB; Integrated Security=SSPI; User ID = edararts; Password=leo123;";
        /// <summary>
        /// Este metodo ayuda a obtener la lista de todos los users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetAllUsers()
        {
            var usersList = new List<Users>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllUsers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var users = new Users();
                    users.Id = Convert.ToInt32(dr["Id"].ToString());
                    users.Nombre = dr["Nombre"].ToString();
                    users.Apellido = dr["Apellido"].ToString();
                    users.Email = dr["Email"].ToString();

                    usersList.Add(users);
                }
                con.Close();
            }
            return usersList;
        }
        /// <summary>
        /// Crear nuevo usuario
        /// </summary>
        /// <param name="users"></param>
        public void CreateUsers(Users users)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Name", users.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", users.Apellido);
                cmd.Parameters.AddWithValue("@Email", users.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Actualizar usuarios
        /// </summary>
        /// <param name="users"></param>
        public void UpdateUsers(Users users)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateUsers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", users.Id);
                cmd.Parameters.AddWithValue("@Name", users.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", users.Apellido);
                cmd.Parameters.AddWithValue("@Email", users.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Eliminar usuarios
        /// </summary>
        /// <param name="users"></param>
        public void DeleteUsers(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteUsers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Eliminar usuarios
        /// </summary>
        /// <param name="users"></param>
        public Users GetUsersById(int? Id)
        {
            var users = new Users();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUsersById", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", Id);
                
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    users.Id = Convert.ToInt32(dr["Id"].ToString());
                    users.Nombre = dr["Nombre"].ToString();
                    users.Apellido = dr["Apellido"].ToString();
                    users.Email = dr["Email"].ToString();
                }
                con.Close();
            }
            return users;
        }
    }
}
