using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using shopGuru_android.Exceptions.UserData;
using shopGuru_android.authenticator;
//using shopGuru_web.XML;
using Android.Content;
using Android.Views;
using shopGuru_android.controller;
using Android.Views.InputMethods;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru",
        Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        private Button _mButtonSignUp;
        private Button _mButtonSignIn;
        private EditText _username;
        private EditText _password;
        private ProgressBar _progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBarLog);
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

            _mButtonSignIn.Click += _mButtonSignIn_Click;

        }

        private  async void _mButtonSignIn_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
            _progressBar.Visibility = ViewStates.Visible;
            try
            {
                bool success = false;

                success = await DataController.LoginDataSubmition(_username.Text, _password.Text);

                _progressBar.Visibility = ViewStates.Invisible;
                if (success)
                {
                    var intent = new Intent(this, typeof(MainActivity));
                    var bundle = new Bundle();
                    bundle.PutString("name", _username.Text);
                    intent.PutExtras(bundle);

                    //preferences save
                    AppPreferences ap = new AppPreferences(this.ApplicationContext);
                    ap.SaveUserName(_username.Text);


                    this.RunOnUiThread(() => Toast.MakeText(this.ApplicationContext, "Welcome!", ToastLength.Long).Show());
                    this.StartActivity(intent);
                    Finish();
                }
                else
                {
                    this.RunOnUiThread(() => Toast.MakeText(this.ApplicationContext, "Invalid name or password", ToastLength.Long).Show());

                    _username.SetTextColor(Android.Graphics.Color.Red);
                    _password.SetTextColor(Android.Graphics.Color.Red);
                }
            }
            catch (UserDataException)
            {
                
            }
        }
    }
}