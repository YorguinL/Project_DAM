using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class DataBaseController : MonoBehaviour
{
    private string conn, sqlQuery;
    private IDbConnection dbconn;
    private IDbCommand dbcmd;
    private IDataReader reader;

    string dataBaseName = "Project_DAM.db";
    private string[] results;

    private int idGame;

    // Start is called before the first frame update
    void Start()
    {
        //Path to database.
        string filepath = Application.dataPath + "/BBDD/" + dataBaseName; 
        
        //Open connection to the database.
        conn = "URI=file:"  + filepath;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); 

        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        SelectAndUpdateRecord();

    }

    // Start game
    private void StartGame() {

        using (dbconn = new SqliteConnection(conn)){

            dbconn.Open(); 
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "INSERT INTO Games (Health, FireRate, PlayerSpeed, KilledEnemies, Level, Score) " + 
                       "VALUES(0, 0, 0, 0, 0, 0);";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }

    }

    // Select max game
    public void SelectMaxIdGame(){

        using(dbconn = new SqliteConnection(conn)){

            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT MAX(Id) FROM Games;";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while(reader.Read()){
                idGame = reader.GetInt32(0);
            }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        }
        
    }

    // Update game record
    private void UpdateGameRecord(int id, int health, int fireRate, int playerSpeed, int killedEnemies, int level, int score){

         using (dbconn = new SqliteConnection(conn)){

            dbconn.Open(); 
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Games " + 
                                     "SET Health = @health, " + 
                                     "FireRate = @fireRate, " +
                                     "PlayerSpeed = @playerSpeed, " +
                                     "KilledEnemies = @killedEnemies, " +
                                     "Level = @level, " +
                                     "Score = @score " +
                                     "WHERE Id = @id");
            
            SqliteParameter p_id =  new SqliteParameter("@id", id);
            SqliteParameter p_health =  new SqliteParameter("@health", health);
            SqliteParameter p_fireRate = new SqliteParameter("@fireRate", fireRate);
            SqliteParameter p_playerSpeed = new SqliteParameter("@playerSpeed", playerSpeed);
            SqliteParameter p_killedEnemies = new SqliteParameter("@killedEnemies", killedEnemies);
            SqliteParameter p_level =  new SqliteParameter("@level", level);
            SqliteParameter p_score =  new SqliteParameter("@score", score);

            dbcmd.Parameters.Add(p_id);
            dbcmd.Parameters.Add(p_health);
            dbcmd.Parameters.Add(p_fireRate);
            dbcmd.Parameters.Add(p_playerSpeed);
            dbcmd.Parameters.Add(p_killedEnemies);
            dbcmd.Parameters.Add(p_level);
            dbcmd.Parameters.Add(p_score);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    // Insert player
    private void InsertPlayer(int id, string nickName, int score){

        using (dbconn = new SqliteConnection(conn)){

            dbconn.Open(); 
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "INSERT INTO Players(IdGame, NickName, Score) "+ 
                       "VALUES (" + id + ", \"" + nickName + "\", " + score + ");";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    // Select top 5
    private void SelectTop5(){

        using(dbconn = new SqliteConnection(conn)){
            int count = 0;
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT NickName, Score " +
                              "FROM Players " +
                              "ORDER BY Score DESC LIMIT 5;";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while(reader.Read()){
                results[count] = reader.GetString(0) + " " + reader.GetInt32(1);
                count++;
            }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        }
    }


    public void SelectAndUpdateRecord(){
        
        if(GameController.Health <= 0){
            SelectMaxIdGame();
            UpdateGameRecord(idGame, 
                             PlayerController.countHealth,
                             PlayerController.countFireRate,
                             PlayerController.countPlayerSpeed,
                             GameController.countKilledEnemies,
                             GameController.level,
                             GameController.score);
        }

    }

    public void NewPlayer(string nkName, int scr){
        InsertPlayer(idGame, nkName, scr);
    }
}
