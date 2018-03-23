using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuditControlSystem.Models
{
    public class AuditSystemDbInitializer : DropCreateDatabaseAlways<AuditContext>
    {
        protected override void Seed(AuditContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "auditor" };
            var role3 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "Administrator" };
            string password = "_Aa123456";
            var result = userManager.Create(admin, password);

            var auditor = new ApplicationUser { Email = "auditor@mail.ru", UserName = "Auditor" };
            string password1 = "_Aa123456";
            var result1 = userManager.Create(auditor, password1);

            var user = new ApplicationUser { Email = "user@mail.ru", UserName = "User" };
            string password2 = "_Aa123456";
            var result2 = userManager.Create(auditor, password2);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(auditor.Id, role2.Name);
                userManager.AddToRole(user.Id, role3.Name);
            }

            base.Seed(context);
        }
        //protected override void Seed(AuditContext db)
        //{
        //    db.Standarts.Add(new Standart { StandartName = "ГОСТ 123", StandartDescription = "Описание 1", StandartFileName = "220" });
        //    db.Standarts.Add(new Standart { StandartName = "ТУ 321", StandartDescription = "Описание 2", StandartFileName = "180" });
        //    db.Standarts.Add(new Standart { StandartName = "Стандарт ТПУ 2018", StandartDescription = "Описание 3", StandartFileName = "150" });

        //    base.Seed(db);
        //}
    }
}