using System.Collections.Generic;
using System.Linq;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        private AutoReservationEntities context = new AutoReservationEntities();

        public List<Auto> Autos()
        {
            return context.Autos.ToList();
        }

        public Auto FindAuto(int id)
        {
            return context.Autos.Find(id);
        }

        public Auto InsertAuto(Auto auto)
        {
            return context.Autos.Add(auto);
        }

        public Auto UpdateAuto(Auto modified, Auto original)
        {
            context.Autos.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);
            return modified;
        }

        public Auto DeleteAuto(Auto auto)
        {
            context.Autos.Attach(auto);
            return context.Autos.Remove(auto);
        }

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}