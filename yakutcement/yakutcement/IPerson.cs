﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakutcement
{
    public class IPerson
    {
        public static void AddPerson(DBContext db, Person user, string fName, string sName, string lName, DateTime bDay, Position pos, double salary, Level level, string login, string password)
        {

        }
        public static bool DeletePerson(DBContext db, Person user, int id)
        {
            if (user.Level == Level.Admin && user.Id != id)
            {
                var p = (from person in db.Persons where person.Id == id select person).FirstOrDefault<Person>();
                db.Persons.Remove(p);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Person Login(DBContext db, string login, string password)
        {
            var user = (from person in db.Persons where person.Login == login select person).FirstOrDefault<Person>();
            if (user != null && user.Password.CompareTo(password) == 0) return user;
            return null;
        }
    }
}
