using System.Collections.Generic;
using System.Linq;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        /**
         *   AUTO
        **/
        public List<Auto> Autos()
        {
            using(var context = new AutoReservationEntities())
            {
                return context.Autos.ToList();
            }
        }

        public Auto FindAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Autos.Find(id);
            }
        }

        public Auto InsertAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                var newAuto = context.Autos.Add(auto);
                context.SaveChanges();
                return newAuto;
            }
        }

        public Auto UpdateAuto(Auto modified, Auto original)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Autos.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                context.SaveChanges();
                return modified;
            }
        }

        public Auto DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Autos.Attach(auto);
                var deletedAuto = context.Autos.Remove(auto);
                context.SaveChanges();
                return deletedAuto;
            }
        }

        /**
         *   Kunden
        **/
        public List<Kunde> Kunden()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunden.ToList();
            }
        }

        public Kunde FindKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunden.Find(id);
            }
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                var newKunde = context.Kunden.Add(kunde);
                context.SaveChanges();
                return newKunde;
            }
        }

        public Kunde UpdateKunde(Kunde modified, Kunde original)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunden.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                context.SaveChanges();
                return modified;
            }
        }

        public Kunde DeleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunden.Attach(kunde);
                var deletedKunde = context.Kunden.Remove(kunde);
                context.SaveChanges();
                return deletedKunde;
            }
        }

        /**
         *   RESERVATION
        **/
        public List<Reservation> Reservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include("Auto").Include("Kunde").ToList();
            }
        }

        public Reservation FindReservation(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include("Auto").Include("Kunde").ToList().Find(i => i.ReservationNr == id);
            }
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                var newReservation = context.Reservationen.Add(reservation);
                context.SaveChanges();
                return newReservation;
            }
        }

        public Reservation UpdateReservation(Reservation modified, Reservation original)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservationen.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                context.SaveChanges();
                return modified;
            }
        }

        public Reservation DeleteReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservationen.Attach(reservation);
                var deletedReservation = context.Reservationen.Remove(reservation);
                context.SaveChanges();
                return deletedReservation;
            }
        }

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}