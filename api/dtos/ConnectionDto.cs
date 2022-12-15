using System;

namespace api.dtos;

public record ConnectionDto(string title, DateTime lastRequestTime)
{
    public bool isOnline => Math.Abs(DateTime.Now.Subtract(lastRequestTime).TotalMinutes) < 1;
}
