using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using UniversityChat.Models;

namespace UniversityChat.Repository
{
    public class DummyRepository
    {
        private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public DummyRepository()
        {

        }

        public void insertUser(UserModel user)
        {
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                string query = "INSERT INTO users(`fname`, `lname`, `username`,`password`, `role`) VALUES ("
                                                                                                        + "'" + user.firstName + " ', "
                                                                                                        + "'" + user.lastName  + " ', " 
                                                                                                        + "'" + user.username  + " ', "
                                                                                                        + "'" + user.password  + " ', "
                                                                                                        + "'" + user.role      + " ' )";
                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool findUserByName(UserModel user)
        {
            string userName = user.username.Trim();
            string password = user.password.Trim();

            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM users WHERE username = (" + "'" + userName + "'" + "AND" + "'" + password + " ' )";

                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();

                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            string dbUserName = dataReader["username"].ToString().Trim();
                            string dbPassword = dataReader["password"].ToString().Trim();
                                                       
                            if (dbUserName.Equals(userName) && dbPassword.Equals(password))
                            {
                                var dbRole = dataReader.GetInt16(3);
                                user.role = dbRole.ToString();

                                return true;
                            }
                        }
                    }
                    
                    connection.Close();
                }
            }
            return false;
        }

        public void insertMessage(MessageModel message)
        {
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                string query = "INSERT INTO messages(message, datetime, username) VALUES (" +  "'"+ message.messageText.Trim() +  "', "
                                                                                                  + "'" + message.dateTime.Trim() +  "', "
                                                                                                  + "'" + message.username.Trim()    +  "' )";
                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IList findMessageByRole(string role)
        {
            IList arrayListMessages = new List<MessageModel>();

            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM messages INNER JOIN users ON users.username = messages.username WHERE role = " + role;

                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();

                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            MessageModel messageModel = new MessageModel();
                            messageModel.messageText = dataReader["message"].ToString();
                            messageModel.username= dataReader["username"].ToString();
                            messageModel.dateTime = dataReader.GetDateTime("datetime").ToString();

                            arrayListMessages.Add(messageModel);
                        }
                    }

                    connection.Close();

                    return arrayListMessages;
                }
            }
        }
    }
}
