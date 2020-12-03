using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLNhanSu.DAL
{
    public class LoginDAOFirebase
    {
        private const String FIREBASE_APP = "https://tiger-group-791db.firebaseio.com/";
        private const String FIREBASE_AUTH = "efqu4diGzBOXC6Ss6ydJfoUctB1OPaCcXYqZavYi";
        static IFirebaseConfig config = new FirebaseConfig { BasePath = FIREBASE_APP, AuthSecret = FIREBASE_AUTH };
        static FirebaseClient client = new FirebaseClient(config);

        public bool LoginToken(String newAnimal, String token)
        {
            try
            {
                client.Set("user/" + newAnimal, token); // custom key
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool CheckToken(String user, String token)
        {
            FirebaseResponse response = client.Get("user/" + user);
            String animal = response.ResultAs<String>();
            if (animal == token)
                return true;
            else return false;
        }

        public String GetToken(String user)
        {
            FirebaseResponse response = client.Get("user/" + user);
            String animal = response.ResultAs<String>();
            return animal;
        }

        public bool History(String user, String action)
        {
            DateTime date = DateTime.Now;
            string Date = date.ToString("dd:MM:yyyy");
            string Time = date.ToString("HH:mm:ss");
            try
            {
                client.Set("history/" + user + "/" + Date + "/" + Time, action); // custom key
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public String GetImage(String id)
        {
            try
            {
                FirebaseResponse response = client.Get("image/" + id);
                String image = response.ResultAs<String>();
                if(image != null)
                return image;
                else
                {
                    response = client.Get("image/" + "default");
                    image = response.ResultAs<String>();
                    return image;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean PostImage(String image, String id)
        {
            try
            {
                client.Set("image/" + id, image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}