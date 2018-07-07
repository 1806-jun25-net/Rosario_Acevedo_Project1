using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsPizza.Library.Function
{
    public class Delete
    {
        public void Deleting(int ID)
        {
            
            using (var db = new LitteJohnsDBContext())
            {
                var Removing = db.Users.SingleOrDefault(X => X.Id == ID); //Deleting function was provided by StackOverFlow in this link: https://stackoverflow.com/questions/17723276/delete-a-single-record-from-entity-framework 
                db.Users.Remove(Removing);
                db.SaveChanges();

            }
        }
        
    }
}
