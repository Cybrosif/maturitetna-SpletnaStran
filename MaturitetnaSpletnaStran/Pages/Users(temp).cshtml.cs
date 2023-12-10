using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaturitetnaSpletnaStran.Classes;
using System.Data.SqlClient;

namespace MaturitetnaSpletnaStran.Pages
{
    public class UsersModel : PageModel
    {
        public List<Users_temp_> clientList = new List<Users_temp_>();
        public void OnGet()
        {
            try
            {
                string conString = "Data Source=.\\sqlexpress;Initial Catalog=Maturitetna;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string sqlQuerry = "SELECT * FROM client_users";
                    using(SqlCommand conCommand = new SqlCommand(sqlQuerry,con))
                    {
                        using (SqlDataReader reader = conCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Users_temp_ user = new Users_temp_();
                                user.id = reader.GetInt32(0);
                                user.name = reader.GetString(2);

                                clientList.Add(user);
                                Console.WriteLine("user added to list");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
