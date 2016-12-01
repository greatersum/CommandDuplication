using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duplication
{
    public class AddEmployeeCmd
    {
        string name;
        string address;
        string city;
        string state;
        string yearlySalary;
        private static readonly char[] header = { (char)0xde, (char)0xad };
        private static readonly char[] commandChar = { (char)0x02 };
        private static readonly char[] footer = { (char)0xbe, (char)0xef };
        private static readonly int SIZE_LENGTH = 1;
        private static readonly int CMD_BYTE_LENGTH = 1;

        private int GetSize()
        {
            return header.Length +
                    SIZE_LENGTH +
                    CMD_BYTE_LENGTH +
                    footer.Length +
                    name.Length + 1 +
                    address.Length + 1 +
                    city.Length + 1 +
                    state.Length + 1 +
                    yearlySalary.Length + 1;
        }

        public AddEmployeeCmd(string name, string address,
                              string city, string state,
                              int yearlySalary)
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.yearlySalary = yearlySalary.ToString();
        }

        public void Write(StreamWriter outputStream)
        {
            outputStream.Write(header);
            outputStream.Write(GetSize());
            outputStream.Write(commandChar);
            outputStream.Write(name);
            outputStream.Write((char)0x00);
            outputStream.Write(address);
            outputStream.Write((char)0x00);
            outputStream.Write(city);
            outputStream.Write((char)0x00);
            outputStream.Write(state);
            outputStream.Write((char)0x00);
            outputStream.Write(yearlySalary);
            outputStream.Write((char)0x00);
            outputStream.Write(footer);
        }
    }

    public class LoginCommand
    {
        private string userName;
        private string passwd;
        private static readonly char[] header = { (char)0xde, (char)0xad };
        private static readonly char[] commandChar = { (char)0x01 };
        private static readonly char[] footer = { (char)0xbe, (char)0xef };
        private static readonly int SIZE_LENGTH = 1;
        private static readonly int CMD_BYTE_LENGTH = 1;

        public LoginCommand(string userName, string passwd)
        {
            this.userName = userName;
            this.passwd = passwd;
        }

        private int GetSize()
        {
            return header.Length + SIZE_LENGTH + CMD_BYTE_LENGTH +
                    footer.Length + userName.Length + 1 +
                    passwd.Length + 1;
        }

        public void Write(StreamWriter outputStream)
        {
            outputStream.Write(header);
            outputStream.Write(GetSize());
            outputStream.Write(commandChar);
            outputStream.Write(userName);
            outputStream.Write((char)0x00);
            outputStream.Write(passwd);
            outputStream.Write((char)0x00);
            outputStream.Write(footer);
        }
    }
}
