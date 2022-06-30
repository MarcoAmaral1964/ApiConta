﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
namespace ApiConta.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ContaContext")
        { }
        public DbSet<Conta> Contas { get; set; }
    }
}