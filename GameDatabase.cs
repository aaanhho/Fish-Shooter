using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;
using SplashKitSDK;

namespace FishShooting
{
    public class GameDatabase
    {
        // The SplashKit Database
        private Database _database;

        //Singleton: only one DB in this game
        private static GameDatabase _instance;

        private GameDatabase()
        {
            _database = SplashKit.OpenDatabase("GameDB", "GameDB");
            Console.WriteLine("DB connected!");
            if (!HaveData())
            {
                Console.WriteLine("DB not initialize!");
                try
                {
                    Query("CREATE TABLE IF NOT EXISTS scores (score INT);");
                    Console.WriteLine("DB initialized!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // If DB exists, return DB. If not, create one
        public static GameDatabase GetDatabase()
        {
            if (_instance == null)
                _instance = new GameDatabase();
            return _instance;
        }

        // Make query
        public QueryResult Query(string sql)
        {
            return _database.RunSql(sql);
        }

        // Check if db contains data
        public bool HaveData()
        {
            QueryResult qr = Query("SELECT COUNT(*) FROM scores");
            return qr.Successful;
        }
    }
}
