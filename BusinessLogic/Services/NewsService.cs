using Core.Concretes.DTOs;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;

namespace BusinessLogic.Services
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetLatestNewsAsync();
    }

    public class NewsService : INewsService
    {
        public Task<List<NewsDto>> GetLatestNewsAsync()
        {
            try
            {
                var url = "https://www.technopat.net/feed/";
                var newsList = new List<NewsDto>();

                using (var reader = XmlReader.Create(url))
                {
                    var feed = SyndicationFeed.Load(reader);
                    foreach (var item in feed.Items)
                    {
                        string description = item.Summary?.Text ?? "";
                        string imageUrl = "";

                        
                        var match = Regex.Match(description, "<img[^>]+src=\"([^\"]+)\"");
                        if (match.Success)
                            imageUrl = match.Groups[1].Value;

                        
                        string cleanDescription = Regex.Replace(description, "<.*?>", "").Trim();
                        cleanDescription = Regex.Replace(cleanDescription, @"\s+", " ").Trim();
                        if (cleanDescription.Length > 200)
                            cleanDescription = cleanDescription.Substring(0, 200) + "...";

                        newsList.Add(new NewsDto
                        {
                            Title = WebUtility.HtmlDecode(item.Title.Text),
                            Description = WebUtility.HtmlDecode(cleanDescription),
                            Url = item.Links.FirstOrDefault()?.Uri.ToString() ?? "",
                            ImageUrl = imageUrl,
                            PublishedAt = item.PublishDate.DateTime
                        });
                    }
                }
                return Task.FromResult(newsList);
            }
            catch (Exception ex)
            {
                // Hata loglanabilir: Console.WriteLine(ex);
                return Task.FromResult(new List<NewsDto>());
            }
        }
    }
} 