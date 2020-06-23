using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.App;

namespace mostrarnotificacion
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher =true)]
    public class MainActivity : AppCompatActivity
         
    {
        internal static readonly string CHANNEL_ID = "local_notification";
        Button btnntf;
        internal static readonly int NOTIFICATION_ID = 1000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            CreateNotificationChannel();
            btnntf = FindViewById<Button>(Resource.Id.buttonNtf);
            btnntf.Click += Btnntf_Click;
            //FragmentManager.BeginTransaction().Replace(Resource.Id.contenedor, new Fragment1()).Commit();

        }

        private void Btnntf_Click(object sender, System.EventArgs e)
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
              .SetSmallIcon(Resource.Drawable.notification_tile_bg)
              .SetContentTitle("Notificacion Pendeja")
              .SetContentText("Suscribete a pewdipie")
              .SetPriority(NotificationCompat.PriorityDefault);
            NotificationManagerCompat notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var name = Resources.GetString(Resource.String.channel_name);
            var description = GetString(Resource.String.channel_description);
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}