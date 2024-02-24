using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork2.BL
{
    public class Vacation
    {
        int id;
        string userId;
        int flatId;
        DateTime startDate;
        DateTime endDate;


        static List<Vacation> vacationsList = new List<Vacation>();

        public Vacation() { }
        public Vacation(int id, string userId, int flatId, DateTime startDate, DateTime endDate)
        {

            Id = id;
            UserId = userId;
            FlatId = flatId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public int FlatId
        {
            get => flatId;
            set
            {
                flatId = value;

            }
        }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                TimeSpan duration = value - StartDate;

                if (value > StartDate && duration.TotalDays <= 20)
                {
                    endDate = value;
                }
                else endDate = DateTime.MinValue;

            }

        }

        //public int CheckFlat(int value)
        //{
        //    //check if the flat is exist need to do it on the dbs.
        //    List<Flat> CheckFlats = Flat.FlatsList;
        //    foreach (Flat item in CheckFlats)
        //    {
        //        if (item.Id == value)
        //        {
        //            return value;
        //        }
        //    }
        //    return -1;
        //}

        public bool Insert()
        {
      
            if (this.flatId == -1 || this.endDate == DateTime.MinValue || IsRented(this))
            {
                return false;
            }

            foreach (var item in vacationsList)
            {
                if (item.id == this.id)
                {
                    return false;
                }
            }


            return true; 
        }

        public bool IsRented(Vacation obj)
        {
            foreach (var item in vacationsList)
            {
                if (item.flatId == obj.flatId && !(item.endDate < obj.startDate || item.startDate > obj.endDate))
                {
                    return true;
                }
            }
            return false;
        }

        //public List<Vacation> Read()
        //{
        //    return vacationsList;
        //}

        public List<Vacation> Read()
        {
            DBservices dbs = new DBservices();

            return dbs.ReadVacations();

        }

        public List<Vacation> ReadByDates(DateTime from, DateTime to)
        {
            List<Vacation> selectedItems = new List<Vacation>();
            foreach (var item in vacationsList)
            {
                if (item.startDate >= from && item.endDate <= to)
                {
                    selectedItems.Add(item);
                }
            }
            return selectedItems;
        }

        public int InsertVacation()
        {
            DBservices dbs = new DBservices();
            return dbs.Insert(this);

        }
    }
}

