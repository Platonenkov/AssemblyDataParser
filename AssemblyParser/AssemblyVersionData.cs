using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AssemblyDataParser.Extensions;

namespace AssemblyDataParser
{
    public class AssemblyVersionData
    {
        /// <summary> Version number (as 1.0.5.3) </summary>
        public string VersionNumber { get; set; }
        /// <summary> Update descriptions, what is new </summary>
        public IEnumerable<string> Description { get; set; }
        /// <summary> Update date time </summary>
        public DateTime? Date { get; set; }

        #region Methods

        /// <summary>
        /// Получает информацию о версиях из файла json
        /// Get Version information from json file
        /// </summary>
        /// <param name="FilePath">file path</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<List<AssemblyVersionData>> GetVersionInfoFromFileAsync(string FilePath, JsonSerializerOptions options = null) =>
            await FilePath.GetDataFromFileAsync<List<AssemblyVersionData>>(options);
        /// <summary>
        /// Получает информацию о версиях из файла json
        /// Get Version information from json file
        /// </summary>
        /// <param name="FilePath">file path</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static List<AssemblyVersionData> GetVersionInfoFromFile(string FilePath, JsonSerializerOptions options = null) =>
            FilePath.GetDataFromFile<List<AssemblyVersionData>>(options);
        /// <summary>
        /// Получает информацию о версиях из файла json
        /// Get Version information from json file
        /// </summary>
        /// <param name="file">file</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<List<AssemblyVersionData>> GetVersionInfoFromFileAsync(FileInfo file, JsonSerializerOptions options = null) =>
            await file.GetDataFromFileAsync<List<AssemblyVersionData>>(options);
        /// <summary>
        /// Получает информацию о версиях из файла json
        /// Get Version information from json file
        /// </summary>
        /// <param name="file">file</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static List<AssemblyVersionData> GetVersionInfoFromFile(FileInfo file, JsonSerializerOptions options = null) =>
            file.GetDataFromFile<List<AssemblyVersionData>>(options);

        /// <summary>
        /// Получает информацию о версиях из потока json
        /// Get Version information from json stream
        /// </summary>
        /// <param name="streame">json stream</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static async Task<List<AssemblyVersionData>> GetVersionInfoFromStreamAsync(Stream streame, JsonSerializerOptions options = null) =>
            await streame.GetDataFromStreamAsync<List<AssemblyVersionData>>(options);
        /// <summary>
        /// Получает информацию о версиях из потока json
        /// Get Version information from json stream
        /// </summary>
        /// <param name="streame">json stream</param>
        /// <param name="options">json options if need</param>
        /// <returns></returns>
        public static List<AssemblyVersionData> GetVersionInfoFromStream(Stream streame, JsonSerializerOptions options = null) =>
            streame.GetDataFromStream<List<AssemblyVersionData>>(options);

        #endregion
    }
}
