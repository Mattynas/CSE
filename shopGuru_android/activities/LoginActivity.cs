using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace shopGuru_android
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private Button mButtonSignUp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            mButtonSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                var client = new localhost.shopGuru_webService();
                client.Login("Martynas", "nesakysiu");
                Console.WriteLine("zjbs");
                /*FragmentTransaction transaction = FragmentManager.BeginTransaction();

                var signUpFragment = new SignUpFragment();
                signUpFragment.Show(transaction,"fragment");*/
            };


        }
    }
}