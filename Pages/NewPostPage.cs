using OpenQA.Selenium;
using System;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static string Title {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                {
                    return title.GetAttribute("value");
                }
                return String.Empty;
            }
        }

        public static void GoTo()
        {
            LeftNavitagion.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.ClassName("wp-heading-inline")).Text == "Edit Page";
        }
    }
}
