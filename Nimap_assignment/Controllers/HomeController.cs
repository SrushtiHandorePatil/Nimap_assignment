using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nimap_assignment.Models;
using PagedList;


namespace Nimap_assignment.Controllers
{

    public class HomeController : Controller
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public ActionResult Product()
        {
            List<Category> category = new List<Category>();
            _ = new List<Category>();
            try
            {

                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, categoryname, active from Categories where active ='Y'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Category comp = new Category();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.categoryname = dr[1].ToString();
                                comp.active = dr[2].ToString();

                                category.Add(comp);
                            }
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return category;

            return View(category);

        }


        public ActionResult Index(int? page)
        {

            List<Product> productsList = new List<Product>();
            try
            {

                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select p.id,p.productname, p.categoryid, ct.categoryname from products p join Categories ct on p.categoryid = ct.id where ct.active='Y' and p.active='Y'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Product comp = new Product();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.productname = dr[1].ToString();
                                comp.categoryid = Convert.ToInt32(dr[2].ToString());
                                comp.categoryname = dr[3].ToString();

                                productsList.Add(comp);
                            }
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return View(productsList);
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Category()
        {
            List<Category> category = new List<Category>();
            try
            {

                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, categoryname, active from Categories where active ='Y'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Category comp = new Category();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.categoryname = dr[1].ToString();
                                comp.active = dr[2].ToString();

                                category.Add(comp);
                            }
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return category;

            return View(category);
        }
        public ActionResult AddCategory(Category category)
        {
            try {
                string sql = "insert into Categories (CategoryName) values('" + category.categoryname + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Category");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public ActionResult editCategory(string id)
        {
            List<Category> category = new List<Category>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, categoryname, active from Categories where id ='" + id + "'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Category comp = new Category();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.categoryname = dr[1].ToString();
                                comp.active = dr[2].ToString();

                                category.Add(comp);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }



            return View(category);
        }




        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                string sql = "update Categories set categoryname = '" + category.categoryname + "' where id = '" + category.id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Category");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public ActionResult deleteCategory(string id)
        {
            try
            {
                string sql = "update Categories set active ='N' where id = '" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Category");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        // product controllers
        public ActionResult AddProduct(Product product)
        {
            try
            {
                string sql = "insert into products (productname, categoryid) values('" + product.productname + "','" + product.categoryid + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Index");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public ActionResult editProduct(string id)
        {
            List<Category> category = new List<Category>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, productname, active from Categories where id ='" + id + "'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Category comp = new Category();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.categoryname = dr[1].ToString();
                                comp.active = dr[2].ToString();

                                category.Add(comp);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }



            return View(category);
        }




        public ActionResult UpdateProduct(Category category)
        {
            try
            {
                con.Open();
                string sql = "update Categories set categoryname = '" + category.productname + "' where id = '" + product.id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Category");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public ActionResult deleteProduct(string id)
        {
            try
            {
                string sql = "update Categories set active ='N' where id = '" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Redirect("/Home/Category");
                }
                else
                {
                    Response.Redirect("/Home/Error");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }
    
    }

    internal class product
    {
        internal static string id;
    }

  



}