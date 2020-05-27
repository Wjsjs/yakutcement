﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakutcement
{
    public class IPerson
    {
        public static void AddPerson(DBContext db, string fName, string sName, string lName, DateTime bDay, Position pos, double salary, Level level, string login, string password)
        {

        }
        public static void DeletePerson(DBContext db, int id)
        {
            var user = (from person in db.Persons where person.Id == id select person).FirstOrDefault<Person>();
            db.Persons.Remove(user);
            db.SaveChanges();
        }
        public static Person Login(DBContext db, string login, string password)
        {
            var user = (from person in db.Persons where person.Login == login select person).FirstOrDefault<Person>();
            if (user != null && user.Password.CompareTo(password) == 0) return user;
            return null;
        }

        // для реализации редактирования в отдельном окне 

        public static void EditPerson(DBContext db, Person user, int id, string fName, string sName, string lName, DateTime bDay, Position pos, double salary, Level level, string login, string password)
        {
            var EditingPerson = (from person in db.Persons where person.Id == id select person).FirstOrDefault<Person>();
            EditingPerson.FirstName = fName;
            EditingPerson.SecondName = sName;
            EditingPerson.LastName = lName;
            EditingPerson.BirthDate = bDay;
            EditingPerson.Position = pos;
            EditingPerson.Salary = salary;
            EditingPerson.Level = level;
            //EditingPerson.Password = password;

            db.SaveChanges();
        }   
    }
}
