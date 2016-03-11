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
            context - это соединение с базой данных
            ir - используется длоя получения результата операции
            объект rm - ссылается на строготипизированный менеджер ролей

            */

            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            ir = rm.Create(new IdentityRole("Admin")); //добавляем роль Admin

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context)); //

            var user = new ApplicationUser() //user - это целый объект с кучей свойств
            {
                UserName = "Admin@admin.com",

            };

            ir = um.Create(user, "password"); //добавляем пользователя
            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }
            ir = um.AddToRole(user.Id, "Admin"); //добавляем созданного юзера к ролям
            return ir.Succeeded;
        }
    }
}
