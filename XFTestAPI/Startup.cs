using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XFTestAPI.DataBaseModel;

namespace XFTestAPI
{
  

    public class Startup
    {

        internal static CarWashVisitDatabase database;

        internal CarWashVisitDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CarWashVisitDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CarWashVisit_DatabaseNew.db3"));
                }
                return database;
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            GenerateDataBase();
        }

        private void GenerateDataBase()
        {
            string fileName = "XF-Test-Json";

            string filePath = Path.GetFullPath(fileName);
            FileInfo fileInfo = new FileInfo(fileName);


            string path = Path.Combine(Environment.CurrentDirectory, @"JsonFile/XF-Test-Json");
            string JSONstring = File.ReadAllText(path);



            CarWashVisitDataModel carwashVisitDetails = JsonConvert.DeserializeObject<CarWashVisitDataModel>(JSONstring, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                GenrateDatabase(carwashVisitDetails);
          
        }


        private async void GenrateDatabase(CarWashVisitDataModel carwashvisit)
        {
            try
            {
               
                foreach (var carwashVisitDetails in carwashvisit.CarwashVisitDetails)
                {
                    Models.CarwashVisitDetails carwashVisit = new Models.CarwashVisitDetails
                    {
                        VisitId = carwashVisitDetails.VisitId,
                        HomeBobEmployeeId = carwashVisitDetails.VisitId,
                        HouseOwnerId = carwashVisitDetails.VisitId,
                        IsBlocked = carwashVisitDetails.IsBlocked,
                        StartTimeUtc = carwashVisitDetails.StartTimeUtc,
                        EndTimeUtc = carwashVisitDetails.EndTimeUtc,
                        Title = carwashVisitDetails.Title,
                        IsReviewed = carwashVisitDetails.IsReviewed,
                        IsFirstVisit = carwashVisitDetails.IsFirstVisit,
                        IsManual = carwashVisitDetails.IsManual,
                        VisitTimeUsed = carwashVisitDetails.VisitTimeUsed,
                        RememberToday = carwashVisitDetails.RememberToday,
                        HouseOwnerFirstName = carwashVisitDetails.HouseOwnerFirstName,
                        HouseOwnerLastName = carwashVisitDetails.HouseOwnerLastName,
                        HouseOwnerMobilePhone = carwashVisitDetails.HouseOwnerMobilePhone,
                        HouseOwnerAddress = carwashVisitDetails.HouseOwnerAddress,
                        HouseOwnerZip = carwashVisitDetails.HouseOwnerZip,
                        HouseOwnerCity = carwashVisitDetails.HouseOwnerCity,
                        HouseOwnerLatitude = carwashVisitDetails.HouseOwnerLatitude,
                        HouseOwnerLongitude = carwashVisitDetails.HouseOwnerLongitude,
                        IsSubscriber = carwashVisitDetails.IsSubscriber,
                        RememberAlways = carwashVisitDetails.RememberAlways,
                        Professional = carwashVisitDetails.Professional,
                        VisitState = carwashVisitDetails.VisitState,
                        StateOrder = carwashVisitDetails.StateOrder,
                        ExpectedTime = carwashVisitDetails.ExpectedTime,
                    };
                    int IsExists = Database.CheckIsExists(carwashVisit);// .Table<CarwashVisitDetails>().Where(array => array.VisitId == taskDetails.TaskId).CountAsync().Result;
                    if (IsExists == 0)
                    {
                        await Database.SaveCarWashDetailsAsync(carwashVisit);
                        foreach (var item in carwashVisitDetails.Tasks)
                        {
                            await Database.SaveTaskDetailsAsync(new Models.TaskDetails
                            {
                                VisitTaskId = carwashVisitDetails.VisitId.ToString(),
                                TaskId = item.TaskId,
                                Title = item.Title,
                                TimesInMinutes = item.TimesInMinutes,
                                IsTemplate = item.IsTemplate,
                                Price = item.Price,
                                PaymentTypeId = item.PaymentTypeId,
                                PaymentTypes = item.PaymentTypes,
                                CreateDateUtc = item.CreateDateUtc,
                                LastUpdateDateUtc = item.LastUpdateDateUtc
                            });
                        }
                    }
                   

                }

               
            }
            catch (Exception)
            {

            }

        }

    }
}
