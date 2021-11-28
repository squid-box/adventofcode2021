namespace AdventOfCode2021
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;

    using AdventOfCode2021.Utils.Extensions;

    using Spectre.Console;

    /// <summary>
    /// Utility for downloading daily input.
    /// </summary>
    public class InputDownloader : IDisposable
    {
        private const string SessionCookieFilename = "session.cookie";
        private readonly string InputFolder = Path.Combine("..", "..", "Input");

        private readonly HttpClientHandler _httpClientHandler;

        public InputDownloader()
        {
            if (!File.Exists(SessionCookieFilename))
            {
                AnsiConsole.MarkupLine($"[red]Unable to find session cookie file \"{SessionCookieFilename}\", unable to download input automatically.[/]");
                return;
            }

            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer.Add(new Cookie("session", File.ReadAllText(SessionCookieFilename), "/", "adventofcode.com"));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _httpClientHandler?.Dispose();
        }

        public void DownloadDay(int day)
        {
            var inputFilePath = Path.Combine(InputFolder, $"{day}.input");

            // Invalid day, or file already exists: Abort.
            if (!day.IsWithin(1, 25) || File.Exists(inputFilePath) || _httpClientHandler == null)
            {
                return;
            }

            try
            {
                using var _httpClient = new HttpClient(_httpClientHandler);
                var input = _httpClient.GetStringAsync($"https://adventofcode.com/2021/day/{day}/input").Result;
                File.WriteAllText(inputFilePath, input);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while downloading input for {day}: {ex.GetType}: {ex.Message}");
            }            
        }
    }
}