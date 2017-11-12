using OpenQA.Selenium;
using System;

namespace WordpressAutomation
{
    internal class MenuSelector
    {
        internal static void Select(string topLevelMenuId, string subMenuLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
            Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
        }
    }
}