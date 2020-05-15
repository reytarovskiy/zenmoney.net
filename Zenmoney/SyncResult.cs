using System.Collections.Generic;
using Zenmoney.Entities;

namespace Zenmoney
{
    public class SyncResult
    {
        public int ServerTimestamp { get; set; }
        public List<Instrument> Instrument { get; } = new List<Instrument>();
        public List<Company> Company { get; } = new List<Company>();
        public List<Account> Account { get; } = new List<Account>();
        public List<User> User { get; } = new List<User>();
        public List<Tag> Tag { get; } = new List<Tag>();
        public List<Merchant> Merchant { get; } = new List<Merchant>();
        public List<Budget> Budget { get; } = new List<Budget>();
        public List<Transaction> Transaction { get; } = new List<Transaction>();
        public List<Deletion> Deletion { get; } = new List<Deletion>();
        public List<Reminder> Reminder { get; } = new List<Reminder>();
    }
}