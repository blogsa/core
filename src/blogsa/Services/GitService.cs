using System.Diagnostics;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace blogsa
{
    public class GitService
    {
        public void Clone(string repoUrl)
        {
            var di = new DirectoryInfo(Path.Combine(Settings.ContentFolder, "_repo"));
            Console.WriteLine($"Repo Folder: {di.FullName}");
            Console.WriteLine($"Is Exists: {di.Exists}");
            if (di.Exists)
            {
                Directory.Delete(di.FullName, true);
                Console.WriteLine("Removed old repo folder.");
            }

            var startInfo = new ProcessStartInfo("git", $"clone {repoUrl} {di.FullName}");
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            var process = Process.Start(startInfo);
            process.WaitForExit(); 
            string q = "";
            if (process.HasExited)
            {
                q = process.StandardOutput.ReadToEnd();
            }
            else
            {
                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }
            }
            Console.WriteLine(q);

            var postsDir = new DirectoryInfo(Path.Combine(di.FullName, "posts"));
            if (postsDir.Exists)
            {
                // TODO: Read posts
            }

            var pagesDir = new DirectoryInfo(Path.Combine(di.FullName, "pages"));
            if (pagesDir.Exists)
            {
                var files = pagesDir.GetFiles("*.md");
                foreach (var file in files)
                {
                    using (var reader = new StreamReader(file.OpenRead()))
                    {
                        var content = reader.ReadToEnd();

                        var page = new PageModel();

                        var titleMatch = new Regex(@"title:([\s]|)(?<title>.+)").Match(content);
                        var nameMatch = new Regex(@"name:([\s]|)(?<name>.+)").Match(content);
                        var dateMatch = new Regex(@"date:([\s]|)(?<date>.+)").Match(content);
                        var urlMatch = new Regex(@"url:([\s]|)(?<url>.+)").Match(content);
                        var templateMatch = new Regex(@"template:([\s]|)(?<template>.+)").Match(content);

                        page.Content = content;
                        if (titleMatch.Success)
                        {
                            page.Title = titleMatch.Groups["title"].Value;
                        }
                        if (nameMatch.Success)
                        {
                            page.Name = nameMatch.Groups["name"].Value;
                        }
                        if (dateMatch.Success)
                        {
                            page.Date = DateTime.Parse(dateMatch.Groups["date"].Value);
                        }
                        if (urlMatch.Success)
                        {
                            page.Url = urlMatch.Groups["url"].Value;
                        }
                        if (templateMatch.Success)
                        {
                            page.Template = templateMatch.Groups["template"].Value;
                        }

                        DataService.Instance.Pages.Add(page);
                    }
                }
            }

            Console.WriteLine($"{DataService.Instance.Pages.Count} page found.");
            Console.WriteLine($"{DataService.Instance.Posts.Count} posts found.");
        }
    }
}