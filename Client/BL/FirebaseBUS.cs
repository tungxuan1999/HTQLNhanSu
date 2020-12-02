using Client.Data;
using Client.Interface;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.BL
{
    class FirebaseBUS
    {
        private const String FIREBASE_APP = DataStatic.urlFirebase;
        static IFirebaseConfig config = new FirebaseConfig { BasePath = FIREBASE_APP };
        static FirebaseClient client = new FirebaseClient(config);


        public async void ListenFirebaseToken()
        {
            EventStreamResponse response = await client.OnAsync("user/" + DataStatic.user,

                changed: (sender, args, context) => { CheckToken(); });

        }

        private void CheckToken()
        {
            if (GetToken() != DataStatic.token)
            {
                Login.login.CheckLogout(true);
            }
        }

        private String GetToken()
        {
            FirebaseResponse response = client.Get("user/" + DataStatic.user);
            String token = response.ResultAs<String>();
            return token;
        }

        public Object GetHistoy(String user)
        {
            FirebaseResponse response = client.Get("history/" + user);
            Object token = response.ResultAs<Object>();
            return token;
        }

        public Object GetHistoyDate(String user, String date)
        {
            FirebaseResponse response = client.Get("history/" + user + "/" + date);
            Object token = response.ResultAs<Object>();
            if (token == null)
            {
                return new Object();
            }
            else
                return token;
        }
    }
}
