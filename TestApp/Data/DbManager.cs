using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestApp.Models;

namespace TestApp.Data
{
    public class DbManager
    {
        string connStr = "server=localhost;user=adm;database=customer;port=3306;password=123456";


        public MySqlDataReader Connect(string query)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            var cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public MySqlConnection SQLConnection()
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            return conn;
        }
        
        public List<Person> PersonReader(MySqlDataReader reader, MySqlConnection conn)
        {
            List<Person> people = new List<Person>();
            while(reader.Read())
            {
                Person p = new Person();
                p.ID = Convert.ToInt32(reader[0]);
                p.FirstName = (string)reader[1];
                p.LastName = (string)reader[2];
                p.age = Convert.ToInt32(reader[3]);
                Debug.WriteLine(p.ID + " " + p.FirstName);
                people.Add(p);
            }
            reader.Close();
            conn.Close();
            return people;
        }
        public List<Adress> AdressReader(MySqlDataReader reader, MySqlConnection conn)
        {
            List<Adress> adresses = new List<Adress>();
            while (reader.Read())
            {
                Adress adress = new Adress();
                adress.ID = Convert.ToInt32(reader[0]);
                adress.Street = (string)reader[1];
                adress.City = (string)reader[2];
                Debug.WriteLine(adress.ID + " " + adress.City);
                adresses.Add(adress);
            }
            reader.Close();
            conn.Close();
            return adresses;
        }

        public List<PersonAdresses> PA_Reader(MySqlDataReader reader, MySqlConnection conn)
        {
            List<PersonAdresses> adresses = new List<PersonAdresses>();
            while (reader.Read())
            {
                PersonAdresses adress = new PersonAdresses();
                adress.FirstName = (string)reader[0];
                adress.LastName = (string)reader[1];
                adress.Age = Convert.ToInt32(reader[2]);
                adress.Street = (string)reader[3];
                adress.City = (string)reader[4];
                adresses.Add(adress);
            }
            reader.Close();
            conn.Close();
            return adresses;
        }

        public PersonAdressViewModel PersonAdressViewModel(MySqlDataReader reader, MySqlConnection conn)
        {
            List<Person> people = new List<Person>();            
            List<Adress> adresses = new List<Adress>();

            while (reader.Read())
            {
                Person p = new Person();
                //p.ID = Convert.ToInt32(reader[0]);
                p.FirstName = (string)reader[0];
                p.LastName = (string)reader[1];
                p.age = Convert.ToInt32(reader[2]);
                Debug.WriteLine(p.ID + " " + p.FirstName);
                people.Add(p);
                Adress adress = new Adress();
                //adress.ID = Convert.ToInt32(reader[0]);
                adress.Street = (string)reader[3];
                adress.City = (string)reader[4];
                Debug.WriteLine(adress.ID + " " + adress.City);
                adresses.Add(adress);
            }

            PersonAdressViewModel pav = new PersonAdressViewModel();
            pav.Person = people;
            pav.Adress = adresses;

            reader.Close();
            conn.Close();
            return pav;
        }
    }
}