using OPMBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class Member {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public MemberStatus Status { get; set; }

        public Member(int id, string name, string email, string address, MemberStatus status) {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Status = status;
        }

        public override string ToString() {
            return $"{Name} ({Status})";
        }

    }
}
