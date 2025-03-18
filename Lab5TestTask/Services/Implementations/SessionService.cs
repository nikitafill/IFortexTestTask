using Lab5TestTask.Data;
using Lab5TestTask.Enums;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5TestTask.Services.Implementations
{
    /// <summary>
    /// SessionService implementation.
    /// </summary>
    public class SessionService : ISessionService
    {
        private readonly ApplicationDbContext _dbContext;

        public SessionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Session> GetSessionAsync()
        {
            return await _dbContext.Sessions
                .Where(s => s.DeviceType == DeviceType.Desktop)
                .OrderBy(s => s.StartedAtUTC)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            return await _dbContext.Sessions
                .Where(s => s.User.Status == UserStatus.Active && s.EndedAtUTC.Year < 2025)
                .ToListAsync();
        }
    }
}