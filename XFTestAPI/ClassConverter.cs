using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XFTestAPI.DataBaseModel;

namespace XFTestAPI
{
    public static class ClassConverter
    {
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Field
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        internal static DataBaseModel.CarwashVisitDetails CastCarwashVisitDetails<T>(Models.CarwashVisitDetails item)
        {

            DataBaseModel.CarwashVisitDetails carwashVisit = new DataBaseModel.CarwashVisitDetails
            {
                VisitId = item.VisitId,
                HomeBobEmployeeId = item.VisitId,
                HouseOwnerId = item.VisitId,
                IsBlocked = item.IsBlocked,
                StartTimeUtc = item.StartTimeUtc,
                EndTimeUtc = item.EndTimeUtc,
                Title = item.Title,
                IsReviewed = item.IsReviewed,
                IsFirstVisit = item.IsFirstVisit,
                IsManual = item.IsManual,
                VisitTimeUsed = item.VisitTimeUsed,
                RememberToday = item.RememberToday,
                HouseOwnerFirstName = item.HouseOwnerFirstName,
                HouseOwnerLastName = item.HouseOwnerLastName,
                HouseOwnerMobilePhone = item.HouseOwnerMobilePhone,
                HouseOwnerAddress = item.HouseOwnerAddress,
                HouseOwnerZip = item.HouseOwnerZip,
                HouseOwnerCity = item.HouseOwnerCity,
                HouseOwnerLatitude = item.HouseOwnerLatitude,
                HouseOwnerLongitude = item.HouseOwnerLongitude,
                IsSubscriber = item.IsSubscriber,
                RememberAlways = item.RememberAlways,
                Professional = item.Professional,
                VisitState = item.VisitState,
                StateOrder = item.StateOrder,
                ExpectedTime = item.ExpectedTime,
                Tasks = new System.Collections.ObjectModel.ObservableCollection<DataBaseModel.TaskDetails>()
            };
            return carwashVisit;

        }

        internal static DataBaseModel.TaskDetails CastTaskDetails<T>(Models.TaskDetails taskDetails)
        {
            DataBaseModel.TaskDetails taskDetail = new DataBaseModel.TaskDetails
            {
                //VisitTaskId = taskDetails.VisitId.ToString(),
                TaskId = taskDetails.TaskId,
                Title = taskDetails.Title,
                TimesInMinutes = taskDetails.TimesInMinutes,
                IsTemplate = taskDetails.IsTemplate,
                Price = taskDetails.Price,
                PaymentTypeId = taskDetails.PaymentTypeId,
                PaymentTypes = taskDetails.PaymentTypes,
                CreateDateUtc = taskDetails.CreateDateUtc,
                LastUpdateDateUtc = taskDetails.LastUpdateDateUtc
            };
            return taskDetail;
        }
    }
}
