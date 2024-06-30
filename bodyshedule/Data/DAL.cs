using bodyshedule.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol;
using System.Security.Claims;


namespace bodyshedule.Data
{
    public interface IDAL
    {
        public List<Event> GetEvents();
        public List<Event> GetMyEvents(int userid);
        public Task<Event> GetEvent(int id);
        public void CreateEvent(IFormCollection form, ApplicationUser appUser, List<ExerciseItem> newItems);
        public void UpdateEvent(IFormCollection form, ApplicationUser appUser);
        public void DeleteEvent(int id);
    }

    public class DAL : IDAL

    {
        private readonly ApplicationDbContext _db;

        public DAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Event> GetEvents()
        {
            return _db.Events.ToList();
        }

        public List<Event> GetMyEvents(int userid)
        {
            return _db.Events.Where(x => x.User.Id == userid).ToList();
        }

        public Task<Event> GetEvent(int id)
        {
            return _db.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void CreateEvent(IFormCollection form, ApplicationUser autUser, List<ExerciseItem> itemList)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == autUser.Id);
            var newEvent = new Event(form, user, itemList);
            _db.Events.Add(newEvent);
            _db.SaveChanges();
        }

        public void UpdateEvent(IFormCollection form, ApplicationUser autUser)
        {
            var eventId = int.Parse(form["Event.id"]);
            var myEvent = _db.Events.FirstOrDefault(x => x.Id == eventId);
            var userId = form["user_id"];
            var user = _db.Users.FirstOrDefault(x => x.Id == autUser.Id);
            myEvent.UpdateEvent(form, user);
            _db.Entry(myEvent).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var myEvent = _db.Events.Find(id);
            var deleteItems = _db.ExerciseItems.Where(item => item.EventId  == id);
            _db.ExerciseItems.RemoveRange(deleteItems);
            _db.Events.Remove(myEvent);
            _db.SaveChanges();
        }

    }


}
