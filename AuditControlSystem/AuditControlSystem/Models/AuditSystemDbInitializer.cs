using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class AuditSystemDbInitializer : DropCreateDatabaseAlways<AuditContext>
    {
        protected override void Seed(AuditContext db)
        {
            db.Standarts.Add(new Standart { StandartName = "ГОСТ 123", StandartDescription = "Описание 1", StandartFileName = "220" });
            db.Standarts.Add(new Standart { StandartName = "ТУ 321", StandartDescription = "Описание 2", StandartFileName = "180" });
            db.Standarts.Add(new Standart { StandartName = "Стандарт ТПУ 2018", StandartDescription = "Описание 3", StandartFileName = "150" });

            base.Seed(db);
        }
    }
}