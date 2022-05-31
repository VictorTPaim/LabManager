﻿using Microsoft.Data.Sqlite; //importar o sqlite
using LabManager.Database; //importa o DatabaseSetup

var databaseSetup = new DatabaseSetup(); //cria uma instância do DatabaseSetup

var modelName = args[0];
var ModelAction = args[1];

if(modelName == "Computer")
{
    if(ModelAction == "List")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); //ABRIR O ARQUIVO/conexão database.db


        var command = connection.CreateCommand(); //comando criado no banco aberto
        command.CommandText = "SELECT * FROM Computers";

        var reader = command.ExecuteReader(); //representa o resultado da tabela

        while(reader.Read())
        {
            Console.WriteLine("{0}, {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2)); //pegar o valor, readers em objeto Computador
        }

        connection.Close(); // fecha a conexão
    }

    if(ModelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); //ABRIR O ARQUIVO/conexão database.db


        var command = connection.CreateCommand(); //comando criado no banco aberto
        command.CommandText = "INSERT INTO Computers VALUES ($id, $ram, $processor)"; //@ - STRING COM QUEBRA DE LINHA
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery(); //create não devolve nada, se fosse select teria retorno
        connection.Close(); // fecha a conexão
    }
}