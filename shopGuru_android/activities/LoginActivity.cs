using System;
using Android.App;
using Android.OS;
using Android.Widget;
using shopGuru_android.Exceptions.UserData;
using shopGuru_android.authenticator;
//using shopGuru_web.XML;
using Android.Content;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru",MainLauncher = true,
        Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        private Button _mButtonSignUp;
        private Button _mButtonSignIn;
        private EditText _username;
        private EditText _password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            _mButtonSignUp = FindViewById<Button>(Resource.Id.btnSignUpLog);
            _mButtonSignIn = FindViewById<Button>(Resource.Id.btnSignInLog);
            _username = FindViewById<EditText>(Resource.Id.txtUsernameLog);
            _password = FindViewById<EditText>(Resource.Id.txtPasswordLog);

            _mButtonSignUp.Click += delegate(object sender, EventArgs args)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                var signUpFragment = new SignUpFragment();
                signUpFragment.Show(transaction,"fragment");
            };

            _mButtonSignIn.Click += (object sender, EventArgs args) =>
            {
                try
                {
                    UserDataValidation.LoginValidation(_username.Text, _password.Text);
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    Finish();
                    /*if (UsersXML.Login(_username.Text, _password.Text))
                    {
                        var intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);
                    }
                    else
                    {
                        _username.SetTextColor(Android.Graphics.Color.Red);
                        _password.SetTextColor(Android.Graphics.Color.Red);
                    }*/
                }
                catch (UserDataException)
                {
                    //For future, display a dialog with message
                    _username.SetTextColor(Android.Graphics.Color.Red);
                    _password.SetTextColor(Android.Graphics.Color.Red);
                }
                //catch(NoConnectionException)
                //For future, display a dialog with message

                
            };

        }
    }
}