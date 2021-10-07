using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ConsoleApp1
{
    //Step - 1 - Install 2 Packages:
    //(1) Microsoft.EntityFrameworkCore.SqlServer
    //(2) And Microsoft.EntityFrameworkCore.Tools

    //Step - 2 - Creating Entities

    [Table("Department")]
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string DName { get; set; }
        public string Description { get; set; }
    }

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Gender { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public int Did { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
    }

    [Table("product")]
    public class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productid { get; set; }

        [Column("ProductName", TypeName = "Varchar(50)")]
        [Required]
        public string ProdName { get; set; }
        public double? PricePerUnit { get; set; }
    }

    //Step - 3 - Creating Context Object -> Adding DbSets
    public class OrganizationDbContext : DbContext
    {
        //Override DbContext
        //This is to generate the Database 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=ROOT\\SQLEXPRESS;Database=OMSdb;Trusted_Connection=True;");
        }

        //DbSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    //Step - 4 - Generating Migration file --> add-migration <filename>
    
    //Step - 5 - Update-database

    class Program
    {
        static void Main(string[] args)
        {
            //var D = new Department() { DName = "Testing", Description = "Testing Department" };

            //OrganizationDbContext dbContext = new OrganizationDbContext();

            //Insert oparation
            //dbContext.Departments.Add(D);
            //dbContext.SaveChanges();

            //Read All records
            //List<Department> departments = dbContext.Departments.ToList();
            //foreach (var d in departments)
            //{
            //    Console.WriteLine($"Did:{d.Did} DName: {d.DName} Description: {d.Description}");
            //}

            //Find a particular record
            //Department d = dbContext.Departments.Find(2);
            //Console.WriteLine($"Did:{d.Did} DName: {d.DName} Description: {d.Description}");

            //Update the record
            //d.DName = "Administrator";
            //d.Description = "New description";

            //dbContext.Departments.Update(d);
            //dbContext.SaveChanges();

            //Delete Record
            //dbContext.Departments.Remove(d);
            //dbContext.SaveChanges();
        }
    }
}