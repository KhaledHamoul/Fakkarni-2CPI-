using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class appointementController
    {
        public static Dictionary<DateTime, List<Appointement>> availableAppointements = new Dictionary<DateTime, List<Appointement>>();
       

        public static void AddAppointement(Appointement appointement)
        {
            DateTime adjustedDay = new DateTime(appointement.dateDebut.Year, appointement.dateDebut.Month, appointement.dateDebut.Day, 0, 0, 0);
            if (availableAppointements.ContainsKey(adjustedDay))
            {
                availableAppointements[adjustedDay].Add(appointement);
            }
            else
            {
                availableAppointements.Add(adjustedDay, new List<Appointement>());
                availableAppointements[adjustedDay].Add(appointement);
            }
        }

        public static bool AddAppointement(DateTime appointementDay, String appointementName, String specialApp, String startHour,String startMinute,String endHour,String endMinute,Enumerations.AppointementType type)
        {
            bool foundInDB = false;
            int startingTimeHour = int.Parse(startHour);
            int endingTimeHour = int.Parse(endHour);
            int startingTimeMinute = int.Parse(startMinute);
            int endingTimeMinute = int.Parse(endMinute);
            if (endingTimeHour - startingTimeHour < 0)
            {
                return false;
            }else if ((endingTimeHour == startingTimeHour)&&(endingTimeMinute - startingTimeMinute <= 0))
            {
                return false;
            }
            if (!CheckAppointementConflict(appointementDay, startHour, startMinute, endHour, endMinute))
            {
                return false;
            }
            else
            {
                DateTime sHour = TimeClass.StringToDateTime(appointementDay, startHour, startMinute);
                DateTime eHour = TimeClass.StringToDateTime(appointementDay, endHour, endMinute);
                Appointement newAppointement;
                if (type == Enumerations.AppointementType.EVENEMENT)
                {
                   newAppointement = new Evenement(1, appointementName, "Priorite", sHour, eHour, specialApp);
                }
                else
                {
                   newAppointement = new Tache(1, appointementName, "Priorite", sHour, eHour, specialApp);
                }
                if (type == Enumerations.AppointementType.EVENEMENT)
                {
                    MonthView.BDDInstance.Insert((Evenement)newAppointement, 1);
                }
                else
                {
                    MonthView.BDDInstance.Insert((Tache)newAppointement, 1, 1);
                }
                if (availableAppointements.ContainsKey(appointementDay))
                {
                    foreach (Appointement appointement in MonthView.BDDInstance.SelectEvents(1))
                    {
                        if (foundInDB) break;
                        if (appointement.dateDebut == newAppointement.dateDebut)
                        {
                            foundInDB = true;
                            availableAppointements[appointementDay].Add(appointement);
                        }
                    }
                    foreach (Appointement appointement in MonthView.BDDInstance.SelectEvents(1))
                    {
                        if (foundInDB) break;
                        if (appointement.dateDebut == newAppointement.dateDebut)
                        {
                            availableAppointements[appointementDay].Add(appointement);
                            foundInDB = true;
                        }
                    }
                }
                else
                {
                    foreach (Appointement appointement in MonthView.BDDInstance.SelectEvents(1))
                    {
                        if (foundInDB) break;
                        if (appointement.dateDebut == newAppointement.dateDebut)
                        {
                            availableAppointements.Add(appointementDay, new List<Appointement>());
                            availableAppointements[appointementDay].Add(appointement);
                            foundInDB = true;
                        }
                    }
                    foreach (Appointement appointement in MonthView.BDDInstance.SelectEvents(1))
                    {
                        if (foundInDB) break;
                        if (appointement.dateDebut == newAppointement.dateDebut)
                        {
                            availableAppointements.Add(appointementDay, new List<Appointement>());
                            availableAppointements[appointementDay].Add(appointement);
                            foundInDB = true;
                        }
                    }
                }
            }
            return true;
        }

        private static bool CheckAppointementConflict(DateTime day,String startHour,String startMin,String endHour,String endMin)
        {
            if (!availableAppointements.ContainsKey(day))
            {
                return true;
            }
            int startingTime = int.Parse(startHour);
            int endingTime = int.Parse(endHour);
            foreach(Appointement appointement in availableAppointements[day])
            {
                String thisAppointementStartHourString = appointement.dateDebut.Hour.ToString();
                String thisAppointementEndHourString = appointement.dateFin.Hour.ToString();
                int thisAppointementStartingHour = int.Parse(thisAppointementStartHourString);
                int thisAppointementEndingHour= int.Parse(thisAppointementEndHourString);
                if (thisAppointementStartingHour <= startingTime && startingTime < thisAppointementEndingHour)
                {
                    return false;
                }else if (thisAppointementStartingHour < endingTime && endingTime <= thisAppointementEndingHour)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
