using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data
{
    public class Config
    {
        public static string ConnectionString => @"Server=localhost\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;";
    }
}
