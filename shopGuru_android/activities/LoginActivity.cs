using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace shopGuru_android
{
    [Activity(Label = "LoginActivity")]
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

            _mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                var signUpFragment = new SignUpFragment();
                signUpFragment.Show(transaction,"fragment");
            };

            _mButtonSignIn.Click += (object sender, EventArgs args) =>
            {
                /*if (WebService.Login(_username.Text, _password.Text))
                {
                    goto.MainMenu();
                }
                else
                {
                    _username.SetTextColor(Android.Graphics.Color.Red);
                    _password.SetTextColor(Android.Graphics.Color.Red);
                }*/
            };

        }
    }
}