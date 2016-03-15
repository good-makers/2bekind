namespace Dobro.WebUI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dobro.WebUI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dobro.WebUI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            AddUserAndRole(context);

        }

        bool AddUserAndRole(Dobro.WebUI.Models.ApplicationDbContext context)
        {
            /*
            context - ��� ���������� � ����� ������
            ir - ������������ ���� ��������� ���������� ��������
            ������ rm - ��������� �� �������������������� �������� �����

            */

            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            ir = rm.Create(new IdentityRole("Admin")); //��������� ���� Admin

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context)); //

            var user = new ApplicationUser() //user - ��� ����� ������ � ����� �������
            {
                UserName = "Admin@admin.com",

            };

            ir = um.Create(user, "password"); //��������� ������������
            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }
            ir = um.AddToRole(user.Id, "Admin"); //��������� ���������� ����� � �����
            return ir.Succeeded;
        }
    }
}
