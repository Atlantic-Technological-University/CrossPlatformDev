using System.Diagnostics;

namespace AppLifecycle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        // The #if DEBUG condition is used to mark code that is only compiled when we are in Debug build.
        // In this scenario we only want to override the default events when running in debug build
        // configuration.
#if DEBUG

        protected override Window CreateWindow(IActivationState activationState)
        {
            //Get the main application window from which we want to subscribe to events
            Window window = base.CreateWindow(activationState);

            window.Activated += (s, e) =>
            {
                Debug.WriteLine("Application Event: window activated");

            };

            // Subscribe to the created event specifying the WindowCreated method to call
            window.Created += new System.EventHandler(WindowCreated);

            // Subscribe to events using anonymous functions
            window.Deactivated += (s, e) =>
            {
                Debug.WriteLine("Application Event: window deactivated");

            };

            window.Destroying += (s, e) =>
            {
                Debug.WriteLine("Application Event: window being destroyed");

            };

            window.Stopped += (s, e) =>
            {
                Debug.WriteLine("Application Event: window being stopped");

            };

            window.Resumed += (s, e) =>
            {
                Debug.WriteLine("Application Event: window being resumed");

            };

            return window;
        }

        /// <summary>
        /// The WindowCreated method just writes a message to the debug console when the window 
        /// created event is triggered within the application. The method demonstrates how to 
        /// subscribe to the event. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowCreated(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Application Event:  window created ");

        }

        //protected override void OnResume()
        //{

        //    Debug.WriteLine("DEBUG: Resuming");

        //    base.OnResume();

        //}

        //protected override void OnSleep()
        //{

        //    Debug.WriteLine("DEBUG: Going to sleep");

        //    base.OnSleep();
        //}

        //protected override void OnStart()
        //{

        //    Debug.WriteLine("DEBUG: starting");

        //    base.OnStart();
        //}

#endif
    }
}