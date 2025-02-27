using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulingApplication.Utilities
{
    public static class LocalizationManager
    {
        private static readonly Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>();
        private static string _currentCulture = "en-US"; // Default to English
        private static string _userLocation = "Unknown";

        // Event that fires when language changes
        public static event EventHandler LanguageChanged;

        static LocalizationManager()
        {
            // Initialize translations
            InitializeTranslations();
        }

        public static void Initialize()
        {
            try
            {
                // Try to detect user's location
                DetectUserLocation();

                // Set culture based on location
                SetCultureBasedOnLocation();
            }
            catch (Exception ex)
            {
                // If there's an error, default to English
                _currentCulture = "en-US";
                _userLocation = "Unknown";

                // Log the error but don't crash the application
                Console.WriteLine($"Error initializing localization: {ex.Message}");
            }
        }

        private static void InitializeTranslations()
        {
            // English translations
            var englishTranslations = new Dictionary<string, string>
        {
            { "LoginWindowTitle", "Login - Scheduling Application" },
            { "ApplicationTitle", "Scheduling Application" },
            { "Username", "Username" },
            { "Password", "Password" },
            { "LoginButton", "Login" },
            { "CancelButton", "Cancel" },
            { "LoggingIn", "Logging in..." },
            { "InvalidCredentials", "Invalid username or password" },
            { "LoginError", "Login error: {0}" },
            { "WelcomeMessage", "Welcome, {0}" },
            { "LogoutConfirmation", "Are you sure you want to logout?" },
            { "Logout", "Logout" },
            { "YourLocation", "Your location: {0}" },
            { "UpcomingAppointmentAlert", "Upcoming Appointment Alert" },
            { "UpcomingAppointmentSingle", "You have an upcoming appointment within the next 15 minutes:" },
            { "UpcomingAppointmentsMultiple", "You have {0} upcoming appointments within the next 15 minutes:" },
            { "ViewDetails", "View Details" },
            { "Close", "Close" }
        };
            Translations["en-US"] = englishTranslations;

            // Spanish translations
            var spanishTranslations = new Dictionary<string, string>
        {
            { "LoginWindowTitle", "Iniciar sesión - Aplicación de Programación" },
            { "ApplicationTitle", "Aplicación de Programación" },
            { "Username", "Nombre de usuario" },
            { "Password", "Contraseña" },
            { "LoginButton", "Iniciar sesión" },
            { "CancelButton", "Cancelar" },
            { "LoggingIn", "Iniciando sesión..." },
            { "InvalidCredentials", "Nombre de usuario o contraseña inválidos" },
            { "LoginError", "Error de inicio de sesión: {0}" },
            { "WelcomeMessage", "Bienvenido, {0}" },
            { "LogoutConfirmation", "¿Está seguro de que desea cerrar sesión?" },
            { "Logout", "Cerrar sesión" },
            { "YourLocation", "Su ubicación: {0}" },
            { "UpcomingAppointmentAlert", "Alerta de Cita Próxima" },
            { "UpcomingAppointmentSingle", "Tiene una cita próxima en los próximos 15 minutos:" },
            { "UpcomingAppointmentsMultiple", "Tiene {0} citas próximas en los próximos 15 minutos:" },
            { "ViewDetails", "Ver Detalles" },
            { "Close", "Cerrar" }
        };
            Translations["es-ES"] = spanishTranslations;
        }

        public static string GetTranslation(string key, params object[] args)
        {
            if (Translations.TryGetValue(_currentCulture, out var cultureDictionary) &&
                cultureDictionary.TryGetValue(key, out var translation))
            {
                // If there are format arguments, apply them
                if (args != null && args.Length > 0)
                {
                    return string.Format(translation, args);
                }
                return translation;
            }

            // Fallback to English
            if (_currentCulture != "en-US" &&
                Translations.TryGetValue("en-US", out var englishDictionary) &&
                englishDictionary.TryGetValue(key, out var englishTranslation))
            {
                if (args != null && args.Length > 0)
                {
                    return string.Format(englishTranslation, args);
                }
                return englishTranslation;
            }

            // If all else fails, return the key itself
            return key;
        }

        public static string CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (Translations.ContainsKey(value) && _currentCulture != value)
                {
                    _currentCulture = value;

                    // Update the current thread culture
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(_currentCulture);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(_currentCulture);

                    // Notify subscribers about the language change
                    LanguageChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static string UserLocation => _userLocation;

        private static void DetectUserLocation()
        {
            try
            {
                // For now, just use the system's region settings as a placeholder
                RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
                _userLocation = regionInfo.DisplayName;
            }
            catch
            {
                _userLocation = "Unknown";
            }
        }

        private static void SetCultureBasedOnLocation()
        {
            // Default to English
            string culture = "en-US";

            try
            {
                // Very simplified example - in a real app, you would use more sophisticated detection
                string systemLanguage = CultureInfo.CurrentCulture.Name;
                if (systemLanguage.StartsWith("es"))
                {
                    culture = "es-ES";
                }
            }
            catch
            {
                culture = "en-US";
            }

            // Set the culture
            CurrentCulture = culture;
        }

        // Allows toggling between available languages
        public static void ToggleLanguage()
        {
            CurrentCulture = (_currentCulture == "en-US") ? "es-ES" : "en-US";
        }
    }
}
