using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
namespace AutomationFrameWork.Selenium
{
   public static class Driver
   {
      private static IWebDriver _webDriver;
      private static WebDriverWait _wait;
      private static string _PathToSave;

      public static IWebDriver WebDriver
      {
         get
         {
            return _webDriver;
         }

         set
         {
            _webDriver = value;
         }
      }

      public static WebDriverWait WebDriverWait
      {
         get
         {
            return _wait;
         }

         set
         {
            _wait = value;
         }
      }


      /// <summary>
      ///method that initializes based on the type of browser
      ///<params name='browserName'>type of the browser</params>
      /// </summary>
      public static void Initialize(string browserName)
      {
         switch (browserName)
         {
            // chnage browsernames to enum types
            case "IE":
               InternetExplorerOptions options = new InternetExplorerOptions
               {
                  EnableNativeEvents = true,
                  RequireWindowFocus = true
               };
               WebDriver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["IDEServerPath"], options,
                  TimeSpan.FromSeconds(90));
               break;

            case "FF":

               WebDriver = GetFirefoxDriver();

               break;

            case "OPERA":

               WebDriver = new OperaDriver(ConfigurationManager.AppSettings["OperaServerPath"]);
               break;

          case "CR":
            default:
               var chromeOptions = new ChromeOptions();
               WebDriver = new ChromeDriver(chromeOptions);
               break;
         }
         WebDriver.Manage().Window.Maximize();
         WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));

      }

      /// <summary>
      ///method that navigates to URL
      /// </summary>
      public static void GoTo(string url)
      {
         _webDriver.Navigate().GoToUrl(url);
      }

      /// <summary>
      ///method that gets the URL
      /// </summary>
      public static string Url => _webDriver.Url;

      /// <summary>
      ///method that closes the driver
      /// </summary>
      public static void Close()
      {
         _webDriver.Close();
         _webDriver.Quit();
      }

    
      private static FirefoxDriver GetFirefoxDriver()
      {
         FirefoxProfile profile = new FirefoxProfile();
         return new FirefoxDriver(new FirefoxOptions
         {
            Profile = profile
         });
      }
   }
}
