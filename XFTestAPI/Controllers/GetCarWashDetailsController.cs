using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XFTestAPI.DataBaseModel;

namespace XFTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCarWashDetailsController : ControllerBase
    {

        [HttpGet]
        [Route("GetCarWashDetailsApi")]
        public ActionResult<CarWashVisitDataModel> GetDetails()
        {
            CarWashVisitDatabase carWashVisitDatabase = new CarWashVisitDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CarWashVisit_DatabaseNew.db3"));
            CarWashVisitDataModel carWashVisitDataModel = new CarWashVisitDataModel();
            carWashVisitDataModel.Code = 200;
            carWashVisitDataModel.Message = "successfully exicuted";
            carWashVisitDataModel.Success = true;
            carWashVisitDataModel.CarwashVisitDetails = new ObservableCollection<CarwashVisitDetails>();
           
            ObservableCollection<Models.CarwashVisitDetails> ListOfCarwashVisitDetails = carWashVisitDatabase.GetCarwashVisitDetailsAsync();
            foreach (var item in ListOfCarwashVisitDetails)
            {


                CarwashVisitDetails carwashVisitDetails = ClassConverter.CastCarwashVisitDetails<CarwashVisitDetails>(item);
                //carwashVisitDetails.Tasks = new ObservableCollection<TaskDetails>();
                ObservableCollection<Models.TaskDetails> ListOfCarwashTaskDetails = carWashVisitDatabase.GetTaskDetailsAsync();
                foreach (var taskDetails in ListOfCarwashTaskDetails)
                {
                    TaskDetails carwashTaskDetails = ClassConverter.CastTaskDetails<TaskDetails>(taskDetails);
                    if(item.VisitId.ToString() == taskDetails.VisitTaskId)
                    {
                        carwashVisitDetails.Tasks.Add(carwashTaskDetails);
                    }
                   
                }
           
                carWashVisitDataModel.CarwashVisitDetails.Add(carwashVisitDetails);
            }
              
            return carWashVisitDataModel;
        }

      

    }

   
}
