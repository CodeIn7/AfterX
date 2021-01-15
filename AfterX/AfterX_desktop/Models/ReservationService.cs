using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_desktop.Models
{
    public class ReservationService
    {
        private static List<Reservation> objReservationList;

        public ReservationService()
        {
            objReservationList = new List<Reservation>()
            {
                new Reservation{Id = 101, TableId = "1", UserId = 1, ReservationDate = "20.1.2021."}
            };
        }

        public List<Reservation> GetAll()
        {
            return objReservationList;
        }

        public bool Add(Reservation objNewReservation)
        {
            objReservationList.Add(objNewReservation);
            return true;
        }

        public bool Update(Reservation objReservationToUpdate)
        {
            bool IsUpdated = false;
            for (int index = 0; index < objReservationList.Count; index++)
            {
                if (objReservationList[index].Id == objReservationToUpdate.Id)
                {
                    objReservationList[index].TableId = objReservationToUpdate.TableId;
                    objReservationList[index].UserId = objReservationToUpdate.UserId;
                    objReservationList[index].ReservationDate = objReservationToUpdate.ReservationDate;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int index = 0; index < objReservationList.Count; index++)
            {
                if (objReservationList[index].Id == id)
                {
                    objReservationList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        public Reservation Search(int id)
        {
            return objReservationList.FirstOrDefault(e => e.Id == id);
        }
    }
}
