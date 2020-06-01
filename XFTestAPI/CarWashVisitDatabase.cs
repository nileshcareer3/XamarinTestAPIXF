using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using XFTestAPI.Models;

namespace XFTestAPI
{
    internal class CarWashVisitDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CarWashVisitDatabase(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                if(!File.Exists(dbPath))
                {
                    _database.CreateTableAsync<CarwashVisitDetails>().Wait();
                    _database.CreateTableAsync<TaskDetails>().Wait();
                }
               
            }
            catch (Exception)
            {

            }

        }

        public ObservableCollection<CarwashVisitDetails> GetCarwashVisitDetailsAsync()
        {
            ObservableCollection<CarwashVisitDetails>  carwashVisitDetails = new ObservableCollection<CarwashVisitDetails>(_database.Table<CarwashVisitDetails>().ToListAsync().Result);

            return carwashVisitDetails;
        }

        public ObservableCollection<TaskDetails> GetTaskDetailsAsync()
        {
            return new ObservableCollection<TaskDetails>(_database.Table<TaskDetails>().ToListAsync().Result);
        }

        public Task<int> SaveCarWashDetailsAsync(CarwashVisitDetails carwashVisitDetails)
        {

            return _database.InsertAsync(carwashVisitDetails);
        }

        public Task<int> SaveTaskDetailsAsync(TaskDetails taskDetails)
        {
            return _database.InsertAsync(taskDetails);
        }

        internal int CheckIsExists(CarwashVisitDetails carwashVisit)
        {
           return _database.Table<CarwashVisitDetails>().Where(array => array.VisitId == carwashVisit.VisitId).CountAsync().Result;
       
        }

        internal int CheckTaskIsExists(TaskDetails taskDetails)
        {
            return _database.Table<CarwashVisitDetails>().Where(array => array.VisitId == taskDetails.TaskId).CountAsync().Result;

        }
    }
}