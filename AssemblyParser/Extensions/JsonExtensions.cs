using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssemblyDataParser.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Получает данные из файла json
        /// Get data from json file
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="FilePath">file path</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<T> GetDataFromFileAsync<T>(this string FilePath, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(FilePath)
        ? default
        : await GetDataFromFileAsync<T>(new FileInfo(FilePath), options);
        /// <summary>
        /// Получает данные из файла json
        /// Get data from json file
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="FilePath">file path</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static T GetDataFromFile<T>(this string FilePath, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(FilePath)
        ? default
        : GetDataFromFile<T>(new FileInfo(FilePath), options);
        /// <summary>
        /// Получает данные из файла json
        /// Get data from json file
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="file">json file</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<T> GetDataFromFileAsync<T>(this FileInfo file, JsonSerializerOptions options = null)
        {
            if (file is null || !file.Exists)
                return default;
            using var streame = file.OpenRead();

            return  await streame.GetDataFromStreamAsync<T>(options);
        } 
        /// <summary>
        /// Получает данные из файла json
        /// Get data from json file
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="file">json file</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static T GetDataFromFile<T>(this FileInfo file, JsonSerializerOptions options = null)
        {
            if (file is null || !file.Exists)
                return default;
            using var streame = file.OpenRead();

            return  streame.GetDataFromStream<T>(options);
        }
        /// <summary>
        /// Получает данные bp потока
        /// Get data from json stream
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="stream">json stream</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<T> GetDataFromStreamAsync<T>(this Stream stream, JsonSerializerOptions options = null)
        {
            if (stream is null)
                return default;
            try
            {
                options ??= new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                };
                options.Converters.Add(new CustomJsonConverterForNullableDateTime());
                var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
                return result;
            }
            catch (Exception)
            {
                return default;
            }

        }
        /// <summary>
        /// Получает данные bp потока
        /// Get data from json stream
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="stream">json stream</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static T GetDataFromStream<T>(this Stream stream, JsonSerializerOptions options = null)
        {
            if (stream is null)
                return default;
            try
            {
                options ??= new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                };
                options.Converters.Add(new CustomJsonConverterForNullableDateTime());
                using var stream_reader = new StreamReader(stream, Encoding.UTF8);
                var data = stream_reader.ReadToEnd();
                var result = JsonSerializer.Deserialize<T>(data, options);
                return result;
            }
            catch (Exception)
            {
                return default;
            }

        }

    }
}
