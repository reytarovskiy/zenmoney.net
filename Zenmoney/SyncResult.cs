using System.Collections.Generic;
using Zenmoney.Entities;

namespace Zenmoney
{
    public class SyncResult
    {
        public List<Instrument> Instrument { get; set; }
        public List<Company> Company { get; set; }
        public List<Account> Account { get; set; }
        public List<User> User { get; set; }
        public List<Tag> Tag { get; set; }
        public List<Merchant> Merchant { get; set; }
        public List<Budget> Budget { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}