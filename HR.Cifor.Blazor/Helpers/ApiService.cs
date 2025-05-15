using System.Net.Http.Json;

namespace HR.Cifor.Blazor.Helpers;

public class ApiService<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<T>>($"{_baseUrl}");
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{id}");
    }

    public async Task<List<T>> SearchAsync(string query)
    {
        var url = string.IsNullOrWhiteSpace(query) ? _baseUrl : $"{_baseUrl}/search?{query}";
        return await _httpClient.GetFromJsonAsync<List<T>>(url);
    }

    public async Task<T?> AddAsync(T item)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUrl, item);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<T>();
        return null;
    }

    public async Task<bool> UpdateAsync(string id, T item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", item);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        return response.IsSuccessStatusCode;
    }
}
