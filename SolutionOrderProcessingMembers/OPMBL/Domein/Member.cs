using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class Member {

        public enum MemberStatus {
            Standard,
            Bronze,
            Silver,
            Gold
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public MemberStatus Status { get; set; }

    }
}
