using System;
using AutomationFrameWork.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationFrameWork.Pages
{
   // class that initializes all the pages with get properties.
   public static class Pages
   {

      private static T GetPage<T>() where T : new()
      {
         var page = new T();
         PageFactory.InitElements(Driver.WebDriver, page);
         return page;
      }

      public static HomePage HomePage => GetPage<HomePage>();
   }
}
