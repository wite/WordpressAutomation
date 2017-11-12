using OpenQA.Selenium;
using System;
using System.Threading;

namespace WordpressAutomation
{
    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish(bool noDraft = true)
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(1));

            var publishButton = Driver.Instance.FindElement(By.Id("publish"));
            publishButton.Click();

            if (noDraft == true)
            {
                Driver.Wait(TimeSpan.FromSeconds(3));
                publishButton.Click();
            }
        }
    }
}